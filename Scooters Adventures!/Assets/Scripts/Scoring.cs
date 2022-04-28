using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    static int totalScore;
    static public int[] scoresAllLevels = new int[4];

    void Start()
    {
        
    }

    static public void UpdateTotalScore()
    {
        for (int i = 0; i < scoresAllLevels.Length; i++)
        {
            totalScore += scoresAllLevels[i];
        }
    }

    static public void IncreaseScore(int amount, Vector3 position, int level)
    {
        scoresAllLevels[level] += amount;
        FloatingText(amount, position);
    }

    static void FloatingText(int amount, Vector3 postition)
    {
        //make it visible on screen in the right position
    }

    static void ResetScore(int level)
    {
        scoresAllLevels[level] = 0;
    }
}
