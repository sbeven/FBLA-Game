using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] public TextMeshPro goodorbad;
    // Start is called before the first frame update
    void Start()
    {
        PermanentUI.perm.LastScene = 5;
        if (PermanentUI.perm.points >= 750)
        {
            goodorbad.text = "As a result of your hard work, you've recieved all 4 awards! Congratulations!";
        }
        else
        {
            goodorbad.text = "Although you didn't get all 4 awards, your dedication to the BAA's goals of service, education, and progress is incredible! Keep working hard!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
