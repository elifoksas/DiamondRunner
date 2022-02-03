using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public Text PanelScoreText;
    private float score;
    private float BestScore;
    public Text BestScoreText;
    public float Score { get => score; set => score = value; }
    private void Start()
    {
        BestScore = PlayerPrefs.GetFloat("BestScore");
    }
    private void Update()
    {
        ScoreText.text = "Score: " + Score.ToString();
        PanelScoreText.text = "Score: " + Score.ToString();

        if (BestScore < Score)
        {
            PlayerPrefs.SetFloat("BestScore", Score);
            BestScoreText.text = "Best\nScore: " + PlayerPrefs.GetFloat("BestScore").ToString();

        }
        else
        {
            BestScoreText.text = "Best\nScore: " + PlayerPrefs.GetFloat("BestScore").ToString();
        }
        
    }
}
