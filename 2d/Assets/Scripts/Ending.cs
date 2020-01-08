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
        PermanentUI.perm.menumusic.Stop();
        PermanentUI.perm.music1.Stop();
        PermanentUI.perm.music2.Stop();
        PermanentUI.perm.music3.Stop();
        PermanentUI.perm.music4.Stop();
        PermanentUI.perm.LastScene = 5;
        PermanentUI.perm.die.Stop();
        if (PermanentUI.perm.points >= 1100)
        {
            goodorbad.text = "As a result of your hard work, you've recieved all 4 awards! Congratulations!";
            PermanentUI.perm.endmusic2.Play();
        }
        else
        {
            PermanentUI.perm.endmusic1.Play();
            goodorbad.text = "Although you didn't get all 4 awards, your dedication to the BAA's goals of service, education, and progress is incredible! Keep working hard!";
        }
    }
}
