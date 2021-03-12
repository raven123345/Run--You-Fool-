using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI lastScore;
    [SerializeField]
    TextMeshProUGUI bestScore;

    private void OnEnable()
    {
        if(PlayerPrefs.HasKey("LastScore"))
        {
            lastScore.text = "Last score: .................. " + PlayerPrefs.GetInt("LastScore");
        }
        else
        {
            lastScore.text = "Last score: .................. " + 0;
        }

        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore.text = "Best score: .................. " + PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            bestScore.text = "Best score: .................. " + 0;
        }
    }
}
