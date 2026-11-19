using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Player_Soldier_Controller : MonoBehaviour
{
    Player_Soldier_Controller controller;
    int layermask = (1 << 11) | (1 << 13);
    Rigidbody rb;
    bool isWalking = false;
    Vector3 startWalkLoc;
    Vector3 progressWalkLoc;
    Vector3 endWalkLoc;
    public float baseSize;
    Vector3 checkBoxSize;
    float mv = 1f;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        checkBoxSize = new Vector3(baseSize/2,baseSize/2,baseSize/2);
        blueScreen = GameObject.FindGameObjectWithTag("Blue_Screen");
        Debug.Log(blueScreen.name);
        tmp = blueScreen.GetComponent<TextMeshProUGUI>();
        controller = GetComponent<Player_Soldier_Controller>();
        plinth = GameObject.FindGameObjectWithTag("Plinth");
        if (plinth != null) plinthController = plinth.GetComponent<Plinth_Controller>();
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
        }
        
        //Instantiate(torus, transform.position, transform.rotation);
    }
    public void stopWalk()
    {
        if (allowMoving)
        {
            isWalking = false;
            endWalkLoc = transform.position;
            endWalkLoc.y = startWalkLoc.y;
            if (Physics.BoxCast(startWalkLoc, checkBoxSize, endWalkLoc - startWalkLoc, transform.rotation, Vector3.Distance(endWalkLoc, startWalkLoc), layermask))
            {
                Debug.Log("Invalid movement.");
                transform.position = startWalkLoc;
                return;
            }
            if (Vector3.Distance(endWalkLoc, startWalkLoc) > mv)
            {
                Debug.Log("Not enough movement left.");
                transform.position = startWalkLoc;
                return;
            }
            else
            {
                mv = mv - Vector3.Distance(endWalkLoc, startWalkLoc);
                Debug.Log("Movement left: " + mv);
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
