using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class HackingMinigame : MonoBehaviour
{
    public GameHandler gameHandler;
    
    public TextMeshProUGUI hackingText;
    public TextMeshProUGUI bubbleText1;
    public TextMeshProUGUI bubbleText2;
    public TextMeshProUGUI bubbleText3;
    public TextMeshProUGUI bubbleText4;
    public TextMeshProUGUI bubbleText5;
    public TextMeshProUGUI bubbleText6;
    public TextMeshProUGUI bubbleText7;
    public TextMeshProUGUI bubbleText8;
    public TextMeshProUGUI bubbleText9;
    public TextMeshProUGUI bubbleText10;
    public TextMeshProUGUI bubbleText11;
    public TextMeshProUGUI bubbleText12;

    public TextMeshProUGUI successFailText;

    public Image fadeScreen;

    private int keyCount;
    private bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("Scripts").GetComponent<GameHandler>();
        keyCount = 0;
        
        // Set all bubble texts to empty strings
        bubbleText1.text = "";
        bubbleText2.text = "";
        bubbleText3.text = "";
        bubbleText4.text = "";
        bubbleText5.text = "";
        bubbleText6.text = "";
        bubbleText7.text = "";
        bubbleText8.text = "";
        bubbleText9.text = "";
        bubbleText10.text = "";
        bubbleText11.text = "";
        bubbleText12.text = "";

        fadeScreen.gameObject.SetActive(false);
        
    }

    private void Update()
    {
        // Everytime the user releases a key, add 1 to keyCount
        if (Input.anyKeyDown)
        {
            keyCount++;
            hackingText.text = "Brute forcing words...";
            ChangeBubbleText();
        }

        
    }

    private void ChangeBubbleText()
    {
        if (keyCount <= 20)
        {
            bubbleText1.text = "*****";
            // Debug.Log(keyCount);
        }

        else if (keyCount <= 40)
        {
            bubbleText1.text = "cat";
            bubbleText2.text = "*****";
        }
        else if (keyCount <= 60)
        {
            bubbleText2.text = "house";
            bubbleText3.text = "*****";
            
        }
        else if (keyCount <= 80)
        {
            bubbleText3.text = "dog";
            bubbleText4.text = "*****";
        }
        else if (keyCount <= 100)
        {
            bubbleText4.text = "mouse";
            bubbleText5.text = "*****";
        }
        else if (keyCount <= 120)
        {
            bubbleText5.text = "bird";
            bubbleText6.text = "*****";
        }
        else if (keyCount <= 140)
        {
            bubbleText6.text = "car";
            bubbleText7.text = "*****";
        }
        else if (keyCount <= 160)
        {
            bubbleText7.text = "tree";
            bubbleText8.text = "*****";
        }
        else if (keyCount <= 180)
        {
            bubbleText8.text = "house";
            bubbleText9.text = "*****";
        }
        else if (keyCount <= 200)
        {
            bubbleText9.text = "mouse";
            bubbleText10.text = "*****";
        }
        else if (keyCount <= 220)
        {
            bubbleText10.text = "bird";
            bubbleText11.text = "*****";
        }
        else if (keyCount <= 240)
        {
            bubbleText11.text = "car";
            bubbleText12.text = "*****";
        }
        else
        {
            if (!won)
            {
                bubbleText12.text = "tree";
                successFailText.text = "SUCCESS!";
                StartCoroutine(ExitWindow());
                gameHandler.WinGame();
                won = true;
            }
            
        }
    }

    IEnumerator ExitWindow()
    {
        yield return new WaitForSeconds(1.5f);

        fadeScreen.gameObject.SetActive(true);
        fadeScreen.CrossFadeAlpha(0, 0, true);
        fadeScreen.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1.5f);

        // Destroy gameobject
        Destroy(gameObject);
    }
}
