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
    public int timescore = 90;
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
    public AudioSource timecrunch;
    public float musicVolume = 1;
    public int checkpoint = 0;
    public Vector2 cppos = Vector2.zero;
    public void Update()
    {
        menumusic.volume = musicVolume;
        music1.volume = musicVolume;
        music2.volume = musicVolume;
        music3.volume = musicVolume;
        music4.volume = musicVolume;
        endmusic1.volume = musicVolume;
        endmusic2.volume = musicVolume;
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
            perm.endmusic1.Stop();
            perm.endmusic2.Stop();
            perm.menumusic.Play();
            perm.music1.Stop();
            perm.music2.Stop();
            perm.music3.Stop();
            perm.music4.Stop();
            perm.die.Stop();
        }

    }
    public void Reset()
    {
        coins = 0;
        levelpoints = 0;
        coinText.text = coins.ToString();
        if(checkpoint == 0)
        {
            if (SceneManager.GetActiveScene().name == "Fourth Level")
            {
                time = 180;
            }
            else
            {
        time = 90;
            }

        }

    }
    //resets lives, adds points, loads transition, resets checkpoint
    public void nextlevel()
    {
        lives = 5;
        points = points + 100;
        SceneManager.LoadScene("Transition");
        checkpoint = 0;
    }
}
