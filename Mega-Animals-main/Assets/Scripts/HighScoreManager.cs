using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public int Puan;
    public TextMeshProUGUI scoreText;
    public int newAnimalPuan= 2;
    public static int animalControl=4;
    public TextMeshProUGUI newAnimalText;
    public TextMeshProUGUI HighScoreText;
    private void Awake()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        scoreText.text = Puan.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        newAnimalText.text = newAnimalPuan.ToString();
    }
    public void ScorManager()
    {
        Puan += 5;
        scoreText.text = Puan.ToString();
        

        if (Puan > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Puan);
            HighScoreText.text = Puan.ToString();
        }
    }
    public void birdScore()
    {
        newAnimalPuan *= 2;
        newAnimalText.text = newAnimalPuan.ToString();
        if (newAnimalPuan == 2048)
        {

            CubeSpawnerScripts.Spawner += 1;
            newAnimalPuan = 2;

            animalControl += 1;
        }
    }
}
