using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecurityQuestionsMinigame : MonoBehaviour
{
    public RandomInfo randomInfo;
    public GameHandler gameHandler;

    public TextMeshProUGUI personalInfoText;

    // Public text mesh pro input field
    public TMP_InputField question1;
    public TMP_InputField question2;
    public TMP_InputField question3;

    public Image checkQuestion1;
    public Image checkQuestion2;
    public Image checkQuestion3;
    public Image fadeScreen;

    public TextMeshProUGUI successFailText;

    private int score;



    // Start is called before the first frame update
    void Start()
    {
        // Find personalInfoText in scene
        personalInfoText = GameObject.Find("Personal Info").GetComponent<TextMeshProUGUI>();
        gameHandler = GameObject.Find("Scripts").GetComponent<GameHandler>();
        randomInfo = GameObject.Find("Scripts").GetComponent<RandomInfo>();

        personalInfoText.text = "<b>Do you remember??</b>";
        question1.onEndEdit.AddListener(SubmitText1);
        question2.onEndEdit.AddListener(SubmitText2);
        question3.onEndEdit.AddListener(SubmitText3);

        checkQuestion1.gameObject.SetActive(false);
        checkQuestion2.gameObject.SetActive(false);
        checkQuestion3.gameObject.SetActive(false);
        fadeScreen.gameObject.SetActive(false);

        successFailText.text = "";

        score = 0;

        // Debug.Log("City: " + randomInfo.personalInfo[1]);
    }

    private void Update()
    {
        if (score >= 3)
        {
            successFailText.text = "SUCCESS!";
            gameHandler.WinGame();
            StartCoroutine(ExitWindow());

            score = 0;
        }
    }

    private void SubmitText1(string text)
    {
        if (text.Trim() == randomInfo.personalInfo[1].Trim())
        {
            checkQuestion1.gameObject.SetActive(true);
            score += 1;
        }

        else
        {
            successFailText.text = "FAILED!";
            gameHandler.FailGame();
            StartCoroutine(ExitWindow());
        }
    }

    private void SubmitText2(string text)
    {
        if (text.Trim() == randomInfo.personalInfo[2].Trim())
        {
            checkQuestion2.gameObject.SetActive(true);
            score += 1;
        }

        else
        {
            successFailText.text = "FAILED!";
            gameHandler.FailGame();
            StartCoroutine(ExitWindow());
            
        }
    }

    private void SubmitText3(string text)
    {
        if (text.Trim() == randomInfo.personalInfo[3].Trim())
        {
            checkQuestion3.gameObject.SetActive(true);
            score += 1;
        }

        else
        {
            successFailText.text = "FAILED!";
            gameHandler.FailGame();
            StartCoroutine(ExitWindow());
            
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