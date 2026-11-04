using UnityEngine;

public class Wobble_Size : MonoBehaviour
{
    Vector3 newScale = new Vector3(1, 1, 1);
    Vector3 baseScale = new Vector3(.75f, .75f, .75f);
    float j;
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
        j += Time.fixedDeltaTime * 1.5f;
        newScale.x = baseScale.x + Mathf.Sin(j) / 4;
        newScale.y = baseScale.y + Mathf.Sin(j) / 4;
        newScale.z = baseScale.z + Mathf.Sin(j) / 4;
        transform.localScale = newScale;
    }
}
