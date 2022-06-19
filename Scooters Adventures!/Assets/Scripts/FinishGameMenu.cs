using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishGameMenu : MonoBehaviour
{
    public GameObject totalScoreText;
    // Start is called before the first frame update
    public void Start()
    {
        totalScoreText.GetComponent<Text>().text = Scoring.totalScore.ToString();
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
