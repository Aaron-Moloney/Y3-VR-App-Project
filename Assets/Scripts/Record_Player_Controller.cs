using UnityEngine;

public class Record_Player_Controller : MonoBehaviour
{
    public GameObject record;
    public GameObject arm;
    public AudioClip clip;
    Quaternion oldRotation;
    float clipTime;
    float counter;
    Vector3 rotateAmount = new Vector3(0, 0.6f, 0);
    Vector3 armRotateAmount;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        oldRotation = arm.transform.localRotation;
        clip = gameObject.GetComponent<AudioSource>().clip;
        clipTime = clip.length;
        armRotateAmount = new Vector3(0, 20 / clipTime * Time.fixedDeltaTime, 0);
        audioSource = GetComponent<AudioSource>();
        //Debug.Log(clipTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (audioSource.isPlaying)
        {
            if (counter > clipTime)
            {
                counter = 0;
                arm.transform.localRotation = oldRotation;
            }
            arm.transform.Rotate(armRotateAmount, Space.Self);
            record.transform.Rotate(rotateAmount, Space.Self);
            counter += Time.deltaTime;
        }
    }

    public void playPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
