using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Managermenu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LevelManager.instance.diffculty = 1;
            SceneManager.LoadScene("Game");

        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            LevelManager.instance.diffculty = 2;
            SceneManager.LoadScene("Game");

        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            LevelManager.instance.diffculty = 3;
            SceneManager.LoadScene("Game");

        }

    }
}
