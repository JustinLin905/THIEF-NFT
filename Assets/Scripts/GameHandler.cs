using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public float totalTime = 120f; // Total time in seconds
    private float currentTime; // Remaining time in seconds
    public TextMeshProUGUI timerText; // UI text element to display the timer

    private int minigame = 0;

    public RandomInfo randomInfo;
    public TextMeshProUGUI personalInfoText;

    public NFTInteract nftInteract;
    public string nftName;

    public GameObject timeOver;
    public GameObject page1;
    public GameObject page2;
    public GameObject page1Button;
    public GameObject page2Button;
    

    // Prefabs
    public GameObject securityMinigame;
    public GameObject hackingMinigame;

    // Array to store won NFTs
    public List<string> stolenNFTs = new List<string>();

    private bool inGame = false;
    private bool timeout = false;

    private void Start()
    {
        currentTime = totalTime; // Initialize the remaining time
        timeOver.SetActive(false);

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        // Update the timer
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // Timer has reached 0, perform any necessary actions
            TimerExpired();
            timeout = true;
        }
    }

    private void UpdateTimerDisplay()
    {
        // Update the timer text display
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }

    private void TimerExpired()
    {
        if (timeout == true) return;

        // Perform actions when the timer reaches 0
        // Debug.Log("Timer expired!");
        timerText.text = "0:00";
        MainMenu.heistReady = false;
        timeOver.SetActive(true);
        
    }

    public void StartMinigame()
    {
        if (inGame) return;
        
        nftInteract = GameObject.Find(nftName).GetComponent<NFTInteract>();

        // Debug.Log("Minigame #:" + minigame);
        // Debug.Log("NFT Name: " + nftName);

        inGame = true;
        
        if (minigame == 0)
        {
            // Instantiate Security Questions Minigame prefab
            GameObject securityQuestionsMinigame = Instantiate(securityMinigame);
            securityQuestionsMinigame.transform.SetParent(GameObject.Find("Canvas").transform, false);
            Debug.Log("Beginning Security Minigame");
        }
        
        else if (minigame == 1)
        {
            // Instantiate Security Questions Minigame prefab
            GameObject hackingGame = Instantiate(hackingMinigame);
            hackingGame.transform.SetParent(GameObject.Find("Canvas").transform, false);
            Debug.Log("Beginning Hacking Minigame");
        }
    }

    public void WinGame()
    {
        inGame = false;
        
        // Reset personal info text if minigame was 0
        if (minigame == 0)
        {
              personalInfoText.text = "<b>City:</b>\n" + randomInfo.personalInfo[1] + "\n\n" + "<b>Favorite Food:</b>\n" + randomInfo.personalInfo[2] + "\n\n" + "<b>Mother's Maiden Name:</b>\n" + randomInfo.personalInfo[3];

        }
        
        minigame += 1;
    
  
        if (minigame >= 2)
        {
            minigame = 0;
        }

        Debug.Log("Game Won, next minigame #: " + minigame);
        nftInteract.WonNFT();
    }

    public void FailGame()
    {
        inGame = false;
        personalInfoText.text = "<b>City:</b>\n" + randomInfo.personalInfo[1] + "\n\n" + "<b>Favorite Food:</b>\n" + randomInfo.personalInfo[2] + "\n\n" + "<b>Mother's Maiden Name:</b>\n" + randomInfo.personalInfo[3];
    }

    public void GoToWallet()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Wallet");
    }

    public void NextPage()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page2Button.SetActive(false);
        page1Button.SetActive(true);
    }

    public void PreviousPage()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page2Button.SetActive(true);
        page1Button.SetActive(false);
    }
}

