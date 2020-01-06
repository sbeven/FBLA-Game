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
            Requirement.text = "The Objective of the Next Level is to Collect All 75 Coins Within 90 Seconds";
            Current.text = "";
        }
        else if (PermanentUI.perm.LastScene == 1)
        {
            Description.text = "The Objective of the Next Level is to Answer All 5 Questions Correctly Within 90 Seconds";
            Requirement.text = "The Required Coins to Access the Next Level is 75";
            Current.text = "Your Current Coins Collected is " + PermanentUI.perm.coins;
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            Description.text = "The Objective of the Next Level is to Recruit All 15 New Members Within 90 Seconds";
            Requirement.text = "The Required Answers to Access the Next Level is all 5";
            Current.text = "Your Current Score is " + PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            Description.text = "Good job!     The Objective of the Next Level is to get to the end in 90 seconds";
            Requirement.text = "";
            Current.text = "";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 4)
        {
            Description.text = "";
            Requirement.text = "The Required Score to Access the Next Level is ";
            Current.text = "Your Current Score is " + PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(PermanentUI.perm.LastScene + 1);
    }
}
