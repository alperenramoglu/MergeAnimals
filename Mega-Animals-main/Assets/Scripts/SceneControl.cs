using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
