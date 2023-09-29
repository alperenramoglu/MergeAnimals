using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public GameObject[] obj;
    public Image HungerBar, HungerBarF;

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

        //FarmManager.score = HighScoreManager.score;
        //HighScoreManager.score = FarmManager.score;
        

        FarmManager.hunger = HungerManager.hunger;
        HungerBarF.fillAmount = FarmManager.hunger;

        



    }



    public void LoadGame()
    {
        HungerManager.hunger = FarmManager.hunger;
        HungerBar.fillAmount = HungerManager.hunger;

        ///HighScoreManager.score = FarmManager.score;

        //FarmManager.score = HighScoreManager.score;
    }
}
