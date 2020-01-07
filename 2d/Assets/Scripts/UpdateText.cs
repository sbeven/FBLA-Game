﻿using System.Collections;
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
            Requirement.text = "The Objective of the Next Level is to collect 75 coins within 90 seconds";
            Current.text = "";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 1)
        {
            Description.text = "The Objective of the Next Level is to Answer All the Questions Correctly within 90 seconds";
            Requirement.text = "The required coins to access the next level is 75";
            Current.text = "You have " + PermanentUI.perm.points +" points";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            Description.text = "The Objective of the Next Level is to Recruit All 15 New Members within 90 seconds";
            Requirement.text = "The required answers to access the next level is all 5";
            Current.text = "Your current score is " + PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            Description.text = "Good job!     The Objective of the Next Level is to get to the end in 90 seconds";
            Requirement.text = "";
            Current.text = "You have " + PermanentUI.perm.points + " points";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 4)
        {
            Description.text = "";
            Requirement.text = "The required score to access the next level is ";
            Current.text = "Your current score is " + PermanentUI.perm.points;
            PermanentUI.perm.Reset();
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene(PermanentUI.perm.LastScene + 1);
    }
}
