using UnityEngine;

public class Enemy_Soldier_Controller : MonoBehaviour
{
    GameObject plinth;
    Plinth_Controller plinthController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plinth = GameObject.FindGameObjectWithTag("Plinth");
        if (plinth != null) plinthController = plinth.GetComponent<Plinth_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void passToPlinth()
    {
        plinthController.setEnemy(this.gameObject);
    }
}
