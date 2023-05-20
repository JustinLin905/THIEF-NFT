using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class NFTInteract : MonoBehaviour
{
    public GameHandler gameHandler;
    public Button stealButton;
    public TextMeshProUGUI stealButtonText;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StealNFT()
    {
        gameHandler.nftName = gameObject.name;
        gameHandler.StartMinigame();
    }

    public void WonNFT()
    {
        stealButtonText.text = "STOLEN!";
        stealButton.interactable = false;

        // Change steal button color to clear
        ColorBlock stealButtonColors = stealButton.colors;
        stealButtonColors.normalColor = new Color(0, 0, 0, 0);
        stealButtonColors.highlightedColor = new Color(0, 0, 0, 0);
        stealButtonColors.pressedColor = new Color(0, 0, 0, 0);
        stealButton.colors = stealButtonColors;

        stealButtonText.CrossFadeColor(new Color(255, 255, 255), 0.5f, false, false);

        // Debug.Log("Button should be disabled");
    }
}
