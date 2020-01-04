using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PermanentUI : MonoBehaviour
{
    //player stats
    public int coins ;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI pointAmount;
    public int points = 0;
    public int levelpoints = 0;
    public string name = "";

    public static PermanentUI perm;
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            name = "";
            points = 0;
        }

        if ((SceneManager.GetActiveScene().name != "Fourth Level") && (SceneManager.GetActiveScene().name != "first level") 
            && (SceneManager.GetActiveScene().name != "Second Level final") && (SceneManager.GetActiveScene().name != "Third Level"))
        {
            Destroy(this.gameObject);
        }
    }
    public void Start()
    {

        DontDestroyOnLoad(this.gameObject);

        //singleton
        if (!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Reset()
    {
        coins = 0;
        points = points - levelpoints;
        levelpoints = 0;
        coinText.text = coins.ToString();
    }
}
