using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    GameObject diceBox;
    Dice_Box_Controller diceBoxController;
    public AudioSource reloadAudio;
    public AudioSource shootAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screen.SetText("Select a model or choose an action.");
        diceBox = GameObject.FindGameObjectWithTag("DiceBox");
        diceBoxController = diceBox.GetComponent<Dice_Box_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (soldierController != null)
        {
            if (soldierController.allowMoving) screen.SetText("Moving " + soldierController.soldierName + "\n" + soldierController.mv + " movement remaining.");
        }
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
        
        canShoot = false;
    }
    public void stopMove()
    {
        xrgb.trackPosition = false;
        soldierController.allowMoving = false;
        canShoot = false;
        screen.SetText("Select a model or choose an action.");
        diceBoxController.disallowRolling();
    }

    public void startShoot()
    {
        xrgb.trackPosition = false;
        soldierController.allowMoving = false;
        if (enemySoldier == null)
        {
            screen.SetText("Select an enemy first");
            return;
        }
        if (enemySoldier.GetComponent<Enemy_Soldier_Controller>().isDead())
        {
            screen.SetText("Enemy already dead.");
            return;
        }
        if (!Physics.Linecast(soldier.transform.position, enemySoldier.transform.position, wallLayerMask))
        {
            if (Physics.Linecast(soldier.transform.position, enemySoldier.transform.position, soldierLayerMask))
            {

                canShoot = true;
                screen.SetText("Target visible");
                soldier.transform.LookAt(enemySoldier.transform);
                reloadAudio.Play();
            }
        }
    }
    public void shoot()
    {
        xrgb.trackPosition = false;
        soldierController.allowMoving = false;
        if (!canShoot) return;
        screen.SetText("Shooting " + enemySoldier.name);
        enemySoldier.GetComponent<Enemy_Soldier_Controller>().kill();
        diceBoxController.allowRolling();
        canShoot = false;
        shootAudio.Play();
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
