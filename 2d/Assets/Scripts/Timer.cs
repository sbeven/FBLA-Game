using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private TextMeshProUGUI timeNumber;
    private float time = 90;

    private void Update()
    {
        time -= 1 * Time.deltaTime;
        timeNumber.text = ("Time: " + Mathf.Round(time).ToString() );
        if(time <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
            PermanentUI.perm.points = PermanentUI.perm.points - 20;
            PermanentUI.perm.Reset();
        }
    }
}
