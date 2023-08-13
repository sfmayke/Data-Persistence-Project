using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUiManager : MonoBehaviour
{
    public Text bestScoreText;
    public Text currentScoreText;

    private void Start()
    {
        ScoreData highestScore = ScoreManager.Instance.GetHighestScore();
        bestScoreText.text += $" {highestScore.name} : {highestScore.score}";
    }

    public void UpdateHihestScoreText()
    {
        ScoreData highestScore = ScoreManager.Instance.HighestScore;
        bestScoreText.text += $" {highestScore.name} : {highestScore.score}";
    }
}
