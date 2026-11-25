using UnityEngine;

public class Enemy_Soldier_Controller : MonoBehaviour
{
    GameObject plinth;
    Plinth_Controller plinthController;
    bool dead = false;
    bool deadAnimated = false;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plinth = GameObject.FindGameObjectWithTag("Plinth");
        if (plinth != null) plinthController = plinth.GetComponent<Plinth_Controller>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (dead && !deadAnimated)
        {
            deadAnimated = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(new Vector3(Random.Range(-5, 5), Random.Range(5, 10), Random.Range(-5, 5)));
            rb.AddTorque(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode.Force);
        }
    }
    public void passToPlinth()
    {
        plinthController.setEnemy(this.gameObject);
    }
    public void kill()
    {
        dead = true;
    }
    public bool isDead() { return dead; }
}
