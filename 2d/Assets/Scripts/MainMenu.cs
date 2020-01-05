using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        PermanentUI.perm.LastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Transition");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Scoreboard()
    {
        SceneManager.LoadScene("Score Board");
    }
}
