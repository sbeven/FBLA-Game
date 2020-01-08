using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniversalControl : MonoBehaviour
{
    private bool Main;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            Main = true;
        } else
        {
            Main = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Main)
        {
            if (Input.GetKey(KeyCode.X))
            {
                PermanentUI.perm.LastScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Transition");
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }
}
