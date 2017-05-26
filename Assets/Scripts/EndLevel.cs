using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    PlayerControls pc;
    public int LoadNextLevel;

    void Start()
    {
        pc = FindObjectOfType<PlayerControls>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pc.NextLevel(LoadNextLevel);
    }
}
