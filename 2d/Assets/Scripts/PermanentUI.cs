using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PermanentUI : MonoBehaviour
{
    //player stats
    public int coins = 0;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI pointAmount;
    public TextMeshProUGUI livesAmount;
    public int points = 0;
    public int levelpoints = 0;
    public string name = "";
    public float time = 90;
    public int LastScene;
    public static PermanentUI perm;
    private Canvas Canvass;
    public int lives;
    public AudioSource menumusic;
    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    public AudioSource music4;
    public AudioSource endmusic1;
    public AudioSource endmusic2;
    public AudioSource die;
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
            Canvass.enabled = false;
        }
        else
        {

            Canvass.enabled = true;

        }
        
    }
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
        
        Canvass = GetComponent<Canvas>();
        lives = 5;
        //singleton
        if (!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            PermanentUI.perm.endmusic1.Stop();
            PermanentUI.perm.endmusic2.Stop();
            PermanentUI.perm.menumusic.Play();
        }

    }
    public void Reset()
    {
        coins = 0;
        points = points + levelpoints;
        levelpoints = 0;
        coinText.text = coins.ToString();
        time = 90;
    }
}
