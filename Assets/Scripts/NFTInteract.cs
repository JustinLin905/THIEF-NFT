using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NFTInteract : MonoBehaviour
{
    public GameHandler gameHandler;
    public Button stealButton;
    
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
        gameHandler.StartMinigame();
    }
}
