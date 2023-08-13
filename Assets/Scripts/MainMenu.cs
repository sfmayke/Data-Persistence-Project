using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Text highestScoreText;

    public void Start()
    {
        ScoreManager.Instance.LoadScoreData();
        ScoreData highestScore = ScoreManager.Instance.HighestScore;
        highestScoreText.text = $"Best Score : {highestScore.name} : {highestScore.score}";
    }

    public void StartGame()
    {
        ScoreManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void save()
    {
        ScoreManager.Instance.SaveScore();
    }
}
