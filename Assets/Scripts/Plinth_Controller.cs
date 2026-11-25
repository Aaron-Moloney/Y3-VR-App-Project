using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Plinth_Controller : MonoBehaviour
{
    GameObject soldier;
    GameObject tempSoldier;
    GameObject enemySoldier;
    XRGrabInteractable xrgb;
    Player_Soldier_Controller soldierController;
    Player_Soldier_Controller tempSoldierController;
    public TextMeshProUGUI screen;
    int soldierLayerMask = 1 << 13;
    int wallLayerMask = 1 << 11;
    bool canShoot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screen.SetText("Select a model or choose an action.");
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
    public void setEnemy(GameObject enemy)
    {
        this.enemySoldier = enemy;
    }
    public void allowMove()
    {
        xrgb.trackPosition = true;
        soldierController.allowMoving = true;
        screen.SetText("Moving " + soldierController.soldierName +"\n" + soldierController.mv + " movement remaining.");
    }
    public void stopMove()
    {
        xrgb.trackPosition = false;
        soldierController.allowMoving = false;
        canShoot = false;
        screen.SetText("Select a model or choose an action.");
    }

    public void startShoot()
    {
        if (enemySoldier == null) screen.SetText("Select an enemy first");
        if (!Physics.Linecast(soldier.transform.position, enemySoldier.transform.position, wallLayerMask))
        {
            if (Physics.Linecast(soldier.transform.position, enemySoldier.transform.position, soldierLayerMask))
            {
                canShoot = true;
                screen.SetText("Target visible");
                soldier.transform.LookAt(enemySoldier.transform);
            }
        }
    }
    public void shoot()
    {
        if (!canShoot) return;
        screen.SetText("Shootig " + enemySoldier.name);
    }
}
