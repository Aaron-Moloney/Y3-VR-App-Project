using UnityEngine;

public class Player_Soldier_Controller : MonoBehaviour
{
    int layermask = (1 << 10) | (1 << 11);
    Rigidbody rb;
    bool isWalking = false;
    Vector3 walkLocInProgress;
    Vector3 fixWalkInProgress;
    //bool isWalking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (isWalking)
        {
            fixWalkInProgress = transform.position;
            fixWalkInProgress.y = walkLocInProgress.y;
            transform.LookAt(walkLocInProgress- transform.position);
        }
    }

    bool checkWalk(Vector3 endLoc)
    {
        return Physics.Linecast(transform.position, endLoc, layermask);
    }
    public void startWalk()
    {
        isWalking = true;
        walkLocInProgress = transform.position;
        //walkLocInProgress.y = ;
    }
    public void stopWalk()
    {
        isWalking = false;
    }
}
