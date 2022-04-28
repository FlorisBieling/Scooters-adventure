using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAgain()
    {
        //this goes from the menu scene to the next scene
        SceneManager.LoadScene(Player.currentScene);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
