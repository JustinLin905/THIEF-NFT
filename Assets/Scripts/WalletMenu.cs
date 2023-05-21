using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletMenu : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI description;

    public GameHandler gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();

        try
        {
            countText.text = gameHandler.stolenNFTs.Count.ToString();
        }
        catch
        {
            countText.text = "Loading Error";
            description.text = "Try Playing a Heist again.";
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

