using Unity.XR.CoreUtils;
using UnityEngine;

public class Dice_Controller : MonoBehaviour
{
    Rigidbody rb;
    GameObject dicebox;
    Dice_Box_Controller diceBoxController;
    int roll = 1;
    float height = 0;
    public GameObject[] faces;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dicebox = GameObject.FindGameObjectWithTag("DiceBox");
        diceBoxController = dicebox.GetComponent<Dice_Box_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude < 0.1f)
        {
            //Debug.Log(rb.linearVelocity.magnitude);
            height = faces[0].transform.position.y;
            roll = faces[0].GetComponent<Face_Value>().value;
            for (int i = 0; i < faces.Length; i ++)
            {
                if ( faces[i].transform.position.y > height)
                {
                    roll = faces[i].GetComponent<Face_Value>().value;
                    height = faces[i].transform.position.y;
                }
            }
            diceBoxController.updateText(roll);
        }
        else
        {
            diceBoxController.rollingText();
            roll = 0;
        }
    }
    public int getRoll()
    {
        return roll;
    }

    public bool stopped()
    {
        return rb.linearVelocity.magnitude < 0.1f;
    }
}
