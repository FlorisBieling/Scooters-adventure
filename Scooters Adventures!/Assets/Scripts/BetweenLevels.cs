using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenLevels : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextLevel()
    {
        SceneManager.LoadScene(Player.currentScene + 1);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
