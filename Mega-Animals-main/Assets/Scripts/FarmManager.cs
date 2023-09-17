using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FarmManager : MonoBehaviour
{


    public GameObject cow, duck, pig, goat, farm;
    public Image farmcolor;
    public Image HungerBar;
    public int spawn;
    public static int score;
    public static float hunger;
    // Start is called before the first frame update
    void Start()
    {
        //CubeSpawnerScripts.SpawnerControl = 5;
        score = HighScoreManager.score;
        hunger = HungerManager.hunger;
        HungerBar.fillAmount = hunger;
    }

    // Update is called once per frame
    void Update()
    {

        farmcolor = farm.GetComponent<Image>();

        var tempColor = farmcolor.color;
        tempColor.a = 1.0f;
        farmcolor.color = tempColor;
        farm.GetComponent<Button>().interactable = true;
        spawn = CubeSpawnerScripts.SpawnerControl;
        score = HighScoreManager.score;
        HungerBar.fillAmount -= 1.0f/200 * Time.deltaTime;
        hunger = HungerBar.fillAmount;
        if (spawn == 5)
        {
            cow.SetActive(true);
        }
        if (spawn == 6)
        {
            cow.SetActive(true);
            duck.SetActive(true);
        }
        if (spawn == 7)
        {
            cow.SetActive(true);
            duck.SetActive(true);
            pig.SetActive(true);
        }
        if (spawn == 8)
        {
            cow.SetActive(true);
            duck.SetActive(true);
            pig.SetActive(true);
            goat.SetActive(true);
        }
    }
}
