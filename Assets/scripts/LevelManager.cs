using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int diffculty;
    void Awake()
    {
        if (instance == null)
        {
            instance=this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
      
        
    }

    void Update()
    {
        
    }
}
