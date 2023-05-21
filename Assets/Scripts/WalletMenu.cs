using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletMenu : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI description;

    public GameHandler gameHandler;

    public GameObject page1;
    public GameObject page2;
    public GameObject page1Button;
    public GameObject page2Button;

    // NFTs
    public GameObject piRabbit;
    public GameObject magicRabbit;
    public GameObject alohaBunny;

    public GameObject hareBrain;
    public GameObject HER;

    public static bool piRabbitOwned;
    public static bool magicRabbitOwned;
    public static bool alohaBunnyOwned;

    public static bool hareBrainOwned;
    public static bool HEROwned;

    static WalletMenu()
    {
        piRabbitOwned = false;
        magicRabbitOwned = false;
        alohaBunnyOwned = false;

        hareBrainOwned = false;
        HEROwned = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page1Button.SetActive(false);
        page2Button.SetActive(true);

        piRabbit.SetActive(false);
        magicRabbit.SetActive(false);
        alohaBunny.SetActive(false);

        hareBrain.SetActive(false);
        HER.SetActive(false);

        gameHandler = FindObjectOfType<GameHandler>();

        try
        {
            countText.text = gameHandler.stolenNFTs.Count.ToString();

            if (FindNFT("Pi Rabbit"))
            {
                piRabbitOwned = true;
            }

            if (FindNFT("Magic Bunny"))
            {
                magicRabbitOwned = true;
            }

            if (FindNFT("Aloha Bunny"))
            {
                alohaBunnyOwned = true;
            }

            if (FindNFT("Hare Brain"))
            {
                hareBrainOwned = true;

            }
            if (FindNFT("HER"))
            {
                HEROwned = true;
            }

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
        if (piRabbitOwned)
        {
            piRabbit.SetActive(true);
        }

        if (magicRabbitOwned)
        {
            magicRabbit.SetActive(true);
        }


        if (alohaBunnyOwned)
        {
            alohaBunny.SetActive(true);
        }
        if (hareBrainOwned)
        {
            hareBrain.SetActive(true);
        }
        if (HEROwned)
        {
            HER.SetActive(true);
        }

    }
    public void ReturnToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private bool FindNFT(string name)
    {
        for (int i = 0; i < gameHandler.stolenNFTs.Count; i++)
        {
            if (gameHandler.stolenNFTs[i] == name)
            {
                return true;
            }
        }

        return false;
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

