using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Player_Soldier_Controller : MonoBehaviour
{
    public string soldierName;
    Player_Soldier_Controller controller;
    int layermask = (1 << 11) | (1 << 13);
    Rigidbody rb;
    bool isWalking = false;
    Vector3 startWalkLoc;
    Vector3 progressWalkLoc;
    Vector3 endWalkLoc;
    public float baseSize;
    Vector3 checkBoxSize;
    public float mv = 1f;
    GameObject blueScreen;
    TextMeshProUGUI tmp;
    XRGrabInteractable xrgb;
    GameObject plinth;
    Plinth_Controller plinthController;
    public bool isSelected = false;
    public bool allowMoving = false;
    bool hasMoved = false;
    public bool allowShooting = false;
    bool hasShot = false;
    float capsuleRadius;
    LineRenderer lineRenderer;
    float walkHeight = 0.575f;
    Vector3 lineRendererPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Checkbox is defined by the capsule colliders radius
        capsuleRadius = GetComponent<CapsuleCollider>().radius;
        baseSize = transform.localScale.x;
        checkBoxSize = new Vector3(baseSize/capsuleRadius, baseSize / capsuleRadius, baseSize / capsuleRadius);
        blueScreen = GameObject.FindGameObjectWithTag("Blue_Screen");
        Debug.Log(blueScreen.name);
        tmp = blueScreen.GetComponent<TextMeshProUGUI>();
        controller = GetComponent<Player_Soldier_Controller>();
        plinth = GameObject.FindGameObjectWithTag("Plinth");
        if (plinth != null) plinthController = plinth.GetComponent<Plinth_Controller>();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (transform.position.y < 0.5) transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
        if (isWalking)
        {
            progressWalkLoc = startWalkLoc;
            progressWalkLoc.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(transform.position - progressWalkLoc);
            lineRenderer.enabled = true;
            lineRendererPos = transform.position;
            lineRendererPos.y = walkHeight;
            lineRenderer.SetPosition(0, startWalkLoc);
            lineRenderer.SetPosition(1, lineRendererPos);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    bool checkWalk(Vector3 endLoc)
    {
        return Physics.Linecast(transform.position, endLoc, layermask);
    }
    public void startWalk()
    {
        if (allowMoving)
        {
            isWalking = true;
            startWalkLoc = transform.position;
            startWalkLoc.y = walkHeight;
        }
    }
    public void stopWalk()
    {
        if (allowMoving)
        {
            isWalking = false;
            endWalkLoc = transform.position;
            endWalkLoc.y = startWalkLoc.y;
            //TODO draw a line representing movement left
            //Physics.CapsuleCast(startWalkLoc, startWalkLoc, capsuleRadius, endWalkLoc - startWalkLoc, Vector3.Distance(endWalkLoc, startWalkLoc), layermask)
            //float distance = Vector3.Distance(lineRendererPos, startWalkLoc) - (baseSize / capsuleRadius);
            //if (distance < 0) distance = 0;
            //Physics.BoxCast(startWalkLoc, checkBoxSize, lineRendererPos - startWalkLoc, transform.rotation, distance, layermask)
            //Capsule with ends at the start and proposed end of the move, radius the same as the soldiers capsule
            //RaycastHit hit;
            //Physics.SphereCast(startWalkLoc, capsuleRadius, lineRendererPos - startWalkLoc, out hit, Vector3.Distance(lineRendererPos, startWalkLoc), layermask)
            if (Physics.Linecast(startWalkLoc, lineRendererPos, layermask))
            {
                Debug.Log("Invalid movement.");
                transform.position = startWalkLoc;
                return;
            }
            if (Vector3.Distance(lineRendererPos, startWalkLoc) > mv)
            {
                Debug.Log("Not enough movement left.");
                transform.position = startWalkLoc;
                return;
            }
            else
            {
                mv = mv - Vector3.Distance(lineRendererPos, startWalkLoc);
                Debug.Log("Movement left: " + mv);
                lineRendererPos.y += 0.1f;
                transform.position = lineRendererPos;
            }
        }
    }

    public void updateText()
    {
        blueScreen.GetComponent<Blue_Screen_Controller>().updateText(mv.ToString());
    }
    public void passToPlinth()
    {
        plinthController.setSoldier(this.gameObject);
    }
}
