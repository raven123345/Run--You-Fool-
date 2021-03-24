using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public int score = 0;

    public TextMeshProUGUI scoreText = null;
    public TextMeshProUGUI bestScore = null;

    public GameObject MusicSlider;
    private void Awake()
    {
        GameObject[] gd = GameObject.FindGameObjectsWithTag("GameData");

        if (gd.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        instance = this;

        PlayerPrefs.SetInt("Score", 0);

        if (!PlayerPrefs.HasKey("BestScore"))
            PlayerPrefs.SetInt("BestScore", 0);

        MusicSlider.GetComponent<UpdateMusic>().Start();
    }

    public void UpdateScore(int s)
    {
        score += s;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        if (bestScore)
        {
            bestScore.text = "Best score: " + PlayerPrefs.GetInt("BestScore");
        }

        PlayerPrefs.SetInt("Score", score);

    }
}
