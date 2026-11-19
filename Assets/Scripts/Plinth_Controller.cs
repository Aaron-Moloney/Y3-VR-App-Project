using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Plinth_Controller : MonoBehaviour
{
    GameObject soldier;
    XRGrabInteractable xrgb;
    Player_Soldier_Controller soldierController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test()
    {
        Debug.Log("Plinth tests");
    }

    public void setSoldier(GameObject soldier)
    {
        this.soldier = soldier;
        this.xrgb = soldier.GetComponent<XRGrabInteractable>();
        this.soldierController = soldier.GetComponent<Player_Soldier_Controller>();
    }
    public void allowMove()
    {
        xrgb.trackPosition = true;
        soldierController.allowMoving = true;
    }
    public void stopMove()
    {
        xrgb.trackPosition = false;
        soldierController.allowMoving = false;

    }
}
