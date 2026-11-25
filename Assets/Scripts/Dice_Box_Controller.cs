using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dice_Box_Controller : MonoBehaviour
{
    public GameObject diceBase;
    GameObject dice;
    Rigidbody diceRB;
    public GameObject diceOrigin;
    public TextMeshProUGUI screen;
    public Button button;
    public AudioSource diceAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (button.enabled == false) screen.SetText("Dice Box.");
    }

    public void roll()
    {
        if (dice == null)
        {
            dice = Instantiate(diceBase, diceOrigin.transform);
            if (diceRB == null)
            {
                diceRB = dice.GetComponent<Rigidbody>();
                diceRB.AddForce(new Vector3(Random.Range(-5, 5), Random.Range(7, 10), Random.Range(-5, 5)));
                diceRB.AddTorque(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode.Force);
                diceAudio.Play();
            }
        }
        else if (dice.GetComponent<Dice_Controller>().stopped())
        {
            diceRB.AddForce(new Vector3(Random.Range(-5, 5), Random.Range(7, 10), Random.Range(-5, 5)));
            diceRB.AddTorque(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode.Force);
            diceAudio.Play();
        }
   
    }

    public void updateText(int input)
    {
        screen.SetText("Result: " + input);
    }
    public void rollingText()
    {
        screen.SetText("Rolling...");
    }
    public void allowRolling()
    {
        button.enabled = true;
    }

    public void disallowRolling()
    {
        button.enabled = false;
    }
}
