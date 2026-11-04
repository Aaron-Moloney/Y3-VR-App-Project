using UnityEngine;

public class Tennis_Ball_Controller : MonoBehaviour
{
    Rigidbody rb;
    AudioSource src;
    AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        src = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter()
    {
        src.volume = rb.linearVelocity.magnitude/15;
        src.PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
    }
}
