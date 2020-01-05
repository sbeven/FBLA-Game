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
        if (PermanentUI.perm.LastScene == 1)
        {
            Description.text = "Next level is";
            Requirement.text = "The required score to access the next level is ";
            Current.text = "Your current score is " + PermanentUI.perm.points;
        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            Description.text = "Next level is";
            Requirement.text = "The required score to access the next level is ";
            Current.text = "Your current score is " + PermanentUI.perm.points;
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            Description.text = "Next level is";
            Requirement.text = "The required score to access the next level is ";
            Current.text = "Your current score is " + PermanentUI.perm.points;
        }
        else if (PermanentUI.perm.LastScene == 4)
        {
            Description.text = "Next level is";
            Requirement.text = "The required score to access the next level is ";
            Current.text = "Your current score is " + PermanentUI.perm.points;
        }
    }
            // Update is called once per frame
            public void NextScene()
    {
        SceneManager.LoadScene(PermanentUI.perm.LastScene + 1);
    }
}
