using TMPro;
using UnityEngine;

public class Blue_Screen_Controller : MonoBehaviour
{
    TextMeshProUGUI tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText(string text)
    {
        tmp.text = text;
    }
}
