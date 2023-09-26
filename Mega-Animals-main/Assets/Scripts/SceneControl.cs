using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SceneControl : MonoBehaviour
{
    public GameObject[] obj;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.FindGameObjectsWithTag("enemy01");
        
    }
    public void LoadFarm()
    {
        FarmManager.score = HighScoreManager.score;
        
        SceneManager.LoadScene(1);
        
        
        
        
        
    }

    

    public void LoadGame()
    {
        HighScoreManager.score = FarmManager.score;
        SceneManager.LoadScene(0);
        
    }
}
