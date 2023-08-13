using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[Serializable]
public class ScoreData
{
    public string name;
    public int score;
}

[Serializable]
class Rank
{
    public List<ScoreData> scores = new();
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private Rank _rank = new();

    private ScoreData _highestScore;
    public ScoreData HighestScore
    {
        get => _highestScore;
        private set => _highestScore = value;
    }

    public string playerName;
    public int playerScore;

    public void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveScore()
    {
        ScoreData score = new() { name = playerName, score = playerScore };
        _rank.scores.Add(score);
        _rank.scores.Sort((score1, score2) => score2.score.CompareTo(score1.score));
        HighestScore = _rank.scores[0];

        string json = JsonConvert.SerializeObject(_rank);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Rank data = JsonConvert.DeserializeObject<Rank>(json);

            _rank = data;
        }
    }

    public ScoreData GetHighestScore()
    {
        return _rank.scores[0];
    }
}
