using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomInfo : MonoBehaviour
{
    public string[] personalInfo = new string[4];

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI personalInfoText;

    void Start()
    {
        personalInfo[0] = GetRandomName();

        TextAsset citiesAsset = Resources.Load<TextAsset>("Cities");
        string[] cities = citiesAsset.text.Split('\n');
        personalInfo[1] = cities[Random.Range(0, cities.Length)];

        TextAsset foodsAsset = Resources.Load<TextAsset>("Foods");
        string[] foods = foodsAsset.text.Split('\n');
        personalInfo[2] = foods[Random.Range(0, foods.Length)];

        TextAsset maidenNamesAsset = Resources.Load<TextAsset>("MaidenNames");
        string[] maidenNames = maidenNamesAsset.text.Split('\n');
        personalInfo[3] = maidenNames[Random.Range(0, maidenNames.Length)];

        nameText.text = personalInfo[0];
        personalInfoText.text = "<b>City:</b>\n" + personalInfo[1] + "\n\n" + "<b>Favorite Food:</b>\n" + personalInfo[2] + "\n\n" + "<b>Mother's Maiden Name:</b>\n" + personalInfo[3];
    }

    string GetRandomName()
    {
        TextAsset namesAsset = Resources.Load<TextAsset>("Names");
        string[] names = namesAsset.text.Split('\n');
        return names[Random.Range(0, names.Length)];
    }
}
