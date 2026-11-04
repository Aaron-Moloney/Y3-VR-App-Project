using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Clock_Controller : MonoBehaviour
{
    [SerializeField]
    private int handType;
    System.DateTime time = System.DateTime.Now;
    float seconds;
    float minutes;
    float hours;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        time = System.DateTime.Now;
        seconds = time.Second;
        minutes = time.Minute +seconds / 60;
        hours = time.Hour % 12 + minutes / 60;
        switch (handType)
        {
            case 0:
                this.transform.localRotation = Quaternion.Euler(seconds * 6 + 90,0 ,-90);
                break;
            case 1:
                this.transform.localRotation = Quaternion.Euler(minutes*6+90, 0, -90);
                break;
            case 3:
                this.transform.localRotation = Quaternion.Euler(hours * 30 +90, 0, -90);
                break;
            default:
                this.transform.localRotation = Quaternion.Euler(time.Second * 6 + 90, 0, time.Second);
                break;
        }
    }
}
