using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeNumber;

    private void Start()
    {
        PermanentUI.perm.time = 90;
    }
    private void Update()
    {
        if ((SceneManager.GetActiveScene().name != "Fourth Level") && (SceneManager.GetActiveScene().name != "first level")
            && (SceneManager.GetActiveScene().name != "Second Level final") && (SceneManager.GetActiveScene().name != "Third Level"))
        {

        }
        else
        {
            PermanentUI.perm.time -= 1 * Time.deltaTime;
            timeNumber.text = ("Time: " + Mathf.Round(PermanentUI.perm.time).ToString() );
        }

        if(PermanentUI.perm.time <= 0)
        {
            PermanentUI.perm.points = PermanentUI.perm.points - PermanentUI.perm.levelpoints - 20;
            PermanentUI.perm.lives = PermanentUI.perm.lives - 1;
            PermanentUI.perm.die.Play();
            SceneManager.LoadScene(PermanentUI.perm.LastScene);
            PermanentUI.perm.Reset();
        }
    }
}
