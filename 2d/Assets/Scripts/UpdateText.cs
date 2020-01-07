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
    public TextMeshProUGUI Current;


    // Start is called before the first frame update
    void Start()
    {
        if (PermanentUI.perm.LastScene == 0)
        {
            Description.text = "";
            Requirement.text = "Service: March of Dimes needs your help fundraising! Collect 75 coins in 90 seconds";
            Current.text = "";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 1)
        {
            Description.text = "Education: Answer 5 questions in 90 seconds to learn about FBLA's Business Achievement Awards!";
            Requirement.text = "You made it! You collected 75 coins and donated to the March of Dimes";
            Current.text = "You have " + (PermanentUI.perm.points+PermanentUI.perm.levelpoints) +" points";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            Description.text = "Progress: Your local chapter needs more members! Recruit 15 members in 90 seconds to get to the next level";
            Requirement.text = "Congratulations! You got them all right!";
            Current.text = "Your current score is " + (PermanentUI.perm.points + PermanentUI.perm.levelpoints);
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            Description.text = "Great Work! Get to the conference as fast as you can to claim your awards!";
            Requirement.text = "";
            Current.text = "You have " + (PermanentUI.perm.points + PermanentUI.perm.levelpoints) + " points";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 4)
        {
            Description.text = "";
            Requirement.text = "";
            Current.text = "Your current score is " + (PermanentUI.perm.points + PermanentUI.perm.levelpoints);
            PermanentUI.perm.Reset();
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene(PermanentUI.perm.LastScene + 1);
    }
}
