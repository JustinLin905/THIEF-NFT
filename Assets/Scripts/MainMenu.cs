using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI scrollingText;
    public TextMeshProUGUI walletText;
    public TextMeshProUGUI playText;
    public Image fadeScreen;
    public static bool heistReady = true;
    public static bool loggedIn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move scrolling text slowly to left
        scrollingText.transform.Translate(Vector2.left * Time.deltaTime * 100);

        if (scrollingText.transform.position.x < -1000)
        {
            scrollingText.transform.position = new Vector2(1800, scrollingText.transform.position.y);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        if (heistReady && loggedIn)
        {
            StartCoroutine(LoadGame());
        }

        else if (heistReady && !loggedIn)
        {
            playText.text = "LOGIN FIRST";
        }

        else if (!heistReady && loggedIn)
        {
            playText.text = "TOMORROW!";
        }
    }

    public void GoToWallet()
    {
        if (loggedIn)
        {
            walletText.text = "LOADING...";
            StartCoroutine(LoadWallet());
        }

        else
        {
            walletText.text = "LOGIN FIRST";
        }
        


    }

    public void Login()
    {
        loggedIn = true;
    }

    IEnumerator LoadGame() {
        // Enable fadeScreen object
        fadeScreen.CrossFadeAlpha(0, 0, true);
        fadeScreen.gameObject.SetActive(true);
        fadeScreen.CrossFadeAlpha(1, 2, false);
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Introduction");
    }

    IEnumerator LoadWallet()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Wallet");
    }
}



