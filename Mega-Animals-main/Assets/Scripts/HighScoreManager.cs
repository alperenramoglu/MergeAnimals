using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    private static HighScoreManager instance;

    public static HighScoreManager Instance { get { return instance; } }

    public int Puan;
    public TextMeshProUGUI scoreText, scoreTextF;
    public int newAnimalPuan= 2;
    public static int animalControl=4;
    public TextMeshProUGUI newAnimalText;
    public TextMeshProUGUI HighScoreText;
    public static int score;
    public Transform effectRefPoint;
    public int[] animalLevels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;

    }
    private void Start()
    {
        //Puan = FarmManager.score;
        score = Puan;
        scoreText.text = Puan.ToString();
        scoreTextF.text = Puan.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        newAnimalText.text = newAnimalPuan.ToString();
        
    }
    public void Update()
    {

        score = Puan;
        
    }
    public void ScorManager(int carpan)
    {
        Puan += 5*carpan;
        scoreText.text = Puan.ToString();

        scoreTextF.text = Puan.ToString();
        if (Puan > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Puan);
            HighScoreText.text = Puan.ToString();
        }
    }
    public void birdScore()
    {
        newAnimalPuan *= 2;////////////////////////////////////2 oalcak
        newAnimalText.text = newAnimalPuan.ToString();
        if (newAnimalPuan == 2048)
        {

            CubeSpawnerScripts.Spawner += 1;
            newAnimalPuan = 2;
            newAnimalText.text = newAnimalPuan.ToString();

            animalControl += 1;
        }
    }
    public void ScorManager2()
    {
        Puan -= 10;
        scoreText.text = Puan.ToString();
        scoreTextF.text = Puan.ToString();
    }

    }
