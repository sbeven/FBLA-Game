using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UpdateText : MonoBehaviour
{
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Requirement;
    public TextMeshProUGUI Coin;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Total;


    // Start is called before the first frame update
    void Start()
    {
        if (PermanentUI.perm.LastScene == 0)
        {
            PermanentUI.perm.menumusic.Stop();
            Description.text = "Service: March of Dimes needs your help fundraising! Collect 75 coins in 90 seconds";
            Requirement.text = "";
            Coin.text = "";
            Level.text = "";
            Total.text = "";
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 1)
        {
            PermanentUI.perm.music1.Stop();
            Description.text = "Education: Answer 5 questions in 90 seconds to learn about FBLA's Business Achievement Awards!";
            Requirement.text = "You made it! You collected 75 coins for your local chapter and donated to the March of Dimes";
            Coin.text = "Coin Bonus: "+ PermanentUI.perm.coins*10;
            Level.text = "Level Bonus: 100";
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            Total.text = "You have "+ PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            PermanentUI.perm.music2.Stop();
            Description.text = "Progress: Your local chapter needs more members! Recruit 15 members in 90 seconds to get to the next level";
            Requirement.text = "Congratulations!   You got them all right!                                ";
            Coin.text = "Coin Bonus: " + PermanentUI.perm.coins * 10;
            Level.text = "Level Bonus: 100";
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            Total.text = "You have " + PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            PermanentUI.perm.music3.Stop();
            Description.text = "Great Work! Get to the conference as fast as you can to claim your awards!";
            Requirement.text = "";
            Coin.text = "Coin Bonus: " + PermanentUI.perm.coins * 10;
            Level.text = "Level Bonus: 100";
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            Total.text = "You have " + PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 4)
        {
            PermanentUI.perm.music4.Stop();
            Description.text = "";
            Requirement.text = "";
            Coin.text = "Coin Bonus: " + PermanentUI.perm.coins * 10;
            Level.text = "Level Bonus: 100";
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            Total.text = "You have " + PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
    }
    public void NextScene()
    {
        
        if (PermanentUI.perm.LastScene == 0)
        {
            PermanentUI.perm.music1.Play();
        }
        else if (PermanentUI.perm.LastScene == 1)
        {
            PermanentUI.perm.music2.Play();
        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            PermanentUI.perm.music3.Play();
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            PermanentUI.perm.music4.Play();
        }
        SceneManager.LoadScene(PermanentUI.perm.LastScene + 1);

    }
}
