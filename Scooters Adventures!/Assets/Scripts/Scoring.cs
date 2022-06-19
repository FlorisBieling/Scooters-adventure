using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    static public int totalScore;
    static public int[] scoresAllLevels;
    static public int scoreCurrentLevel;

    static public GameObject scoreText;
    static public GameObject totalScoreText;

    void Start()
    {
        scoresAllLevels = new int[SceneManager.sceneCountInBuildSettings];
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
        totalScoreText = GameObject.FindGameObjectWithTag("TotalScoreText");
    }

    static public void UpdateTotalScore()
    {
        //reset score first
        totalScore = 0;

        //check points for all levels
        for (int i = 0; i < scoresAllLevels.Length; i++)
        {
            totalScore += scoresAllLevels[i];
        }
    }

    static public void IncreaseScore(int amount, Vector3 position, int level)
    {
        scoresAllLevels[level] += amount;
        UpdateTotalScore();

        FloatingText(amount, position);
        UpdateScoreText(level);
    }

    static public void UpdateScoreText(int level)
    {
        scoreText.GetComponent<Text>().text = scoresAllLevels[level].ToString();
        totalScoreText.GetComponent<Text>().text = totalScore.ToString();
    }

    static void FloatingText(int amount, Vector3 postition)
    {
        //make it visible on screen in the right position
    }

    static public void ResetScore(int level)
    {
        scoresAllLevels[level] = 0;
        UpdateTotalScore();
    }
}
