using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionScript : MonoBehaviour
{
    public Image fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {

           StartCoroutine(LoadGame());

    }

    IEnumerator LoadGame()
    {
        // Enable fadeScreen object
        fadeScreen.CrossFadeAlpha(0, 0, true);
        fadeScreen.gameObject.SetActive(true);
        fadeScreen.CrossFadeAlpha(1, 2, false);
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
