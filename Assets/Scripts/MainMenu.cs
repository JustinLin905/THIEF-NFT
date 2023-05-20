using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI scrollingText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move scrolling text slowly to left
        scrollingText.transform.Translate(Vector2.left * Time.deltaTime * 50);

        if (scrollingText.transform.position.x < -1000)
        {
            scrollingText.transform.position = new Vector2(1800, scrollingText.transform.position.y);
        }
    }
}

