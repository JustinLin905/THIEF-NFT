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

    // Prefabs
    public GameObject securityMinigame;
    public GameObject hackingMinigame;

    // Array to store won NFTs
    public List<string> stolenNFTs = new List<string>();

    private void Start()
    {
        currentTime = totalTime; // Initialize the remaining time
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
        // Perform actions when the timer reaches 0
        Debug.Log("Timer expired!");
    }

    public void StartMinigame()
    {
        nftInteract = GameObject.Find(nftName).GetComponent<NFTInteract>();

        // Debug.Log("Minigame #:" + minigame);
        Debug.Log("NFT Name: " + nftName);
        
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
        personalInfoText.text = "<b>City:</b>\n" + randomInfo.personalInfo[1] + "\n\n" + "<b>Favorite Food:</b>\n" + randomInfo.personalInfo[2] + "\n\n" + "<b>Mother's Maiden Name:</b>\n" + randomInfo.personalInfo[3];
    }
}
