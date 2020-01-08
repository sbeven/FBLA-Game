using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject Menu;
//    public static bool firstCall = true;
    public Slider volume;

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

    private void Awake()
    {
        //if (firstCall)
        //{
        //    Instructions.SetActive(true);
        //    Menu.SetActive(false);

        //}
        //firstCall = false;
    }

    private void Update()
    {
        PermanentUI.perm.musicVolume = volume.value;
    }
}
