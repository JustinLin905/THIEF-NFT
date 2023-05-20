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
    
    // Start is called before the first frame update
    void Start()
    {
        // Set element 0 to a random name from Names.txt
        personalInfo[0] = GetRandomName();

        // Debug.Log(personalInfo[0]);

        // Generate random city
        string[] cities = System.IO.File.ReadAllLines("Assets/Scripts/Cities.txt");
        personalInfo[1] = cities[Random.Range(0, cities.Length)];

        // Generate random food
        string[] foods = System.IO.File.ReadAllLines("Assets/Scripts/Foods.txt");
        personalInfo[2] = foods[Random.Range(0, foods.Length)];

        // Generate random mother's maiden name
        string[] maidenNames = System.IO.File.ReadAllLines("Assets/Scripts/MaidenNames.txt");
        personalInfo[3] = maidenNames[Random.Range(0, maidenNames.Length)];

        nameText.text = personalInfo[0];
        personalInfoText.text = "<b>City:</b>\n" + personalInfo[1] + "\n\n" + "<b>Favorite Food:</b>\n" + personalInfo[2] + "\n\n" + "<b>Mother's Maiden Name:</b>\n" + personalInfo[3];
    }

    string GetRandomName()
    {
        // Read all lines from Names.txt, found in Assets/Scripts
        string[] names = System.IO.File.ReadAllLines("Assets/Scripts/Names.txt");

        // Return a random name from the array
        return names[Random.Range(0, names.Length)];
    }
}
