using UnityEngine;

public class Lighter_Controller : MonoBehaviour
{
    public GameObject flameSource;
    //SphereCollider sc;
    AudioSource source;
    //public GameObject lightSource;
    //Light light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sc = GetComponent<SphereCollider>();
        source = GetComponent<AudioSource>();
        //light = lightSource.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleLighter()
    {
        Debug.Log("Here!");
        //sc.enabled = !sc.enabled;
        //sc.SetActive(!sc.gameObject.activeSelf);
        flameSource.SetActive(!flameSource.gameObject.activeSelf);
        //sphereSource.gameObject.SetActive(!sphereSource.gameObject.activeSelf);
    }
    public void playAudio()
    {
        source.Play();
    }
}
