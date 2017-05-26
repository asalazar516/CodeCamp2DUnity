using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FallOut : MonoBehaviour
{
    //float Timer = 2;
   //public Text DeathText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fallout"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
