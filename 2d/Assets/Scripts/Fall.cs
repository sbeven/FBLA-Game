using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PermanentUI.perm.lives = PermanentUI.perm.lives - 1;
            if (PermanentUI.perm.hardBool)
            {
                PermanentUI.perm.points = PermanentUI.perm.points - 200;
            }
            else
            {
                PermanentUI.perm.points = PermanentUI.perm.points - 20;

            }
            PermanentUI.perm.die.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PermanentUI.perm.Reset();
        }
    }
}
