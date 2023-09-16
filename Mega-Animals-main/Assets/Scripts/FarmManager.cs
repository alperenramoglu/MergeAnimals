using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FarmManager : MonoBehaviour
{


    public GameObject cow, duck, pig, goat, farm;
    public Image HungerBar;
    public int spawn;
    // Start is called before the first frame update
    void Start()
    {
        //CubeSpawnerScripts.SpawnerControl = 5;

    }

    // Update is called once per frame
    void Update()
    {
        spawn = CubeSpawnerScripts.SpawnerControl;
        HungerBar.fillAmount -= 1.0f/250 * Time.deltaTime;
        if (CubeSpawnerScripts.Spawner == 5)
        {
            cow.SetActive(true);
        }
        if (CubeSpawnerScripts.Spawner == 6)
        {
            duck.SetActive(true);
        }
        if (CubeSpawnerScripts.Spawner == 7)
        {
            pig.SetActive(true);
        }
        if (CubeSpawnerScripts.Spawner == 8)
        {
            goat.SetActive(true);
        }
    }
}
