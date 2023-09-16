using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawnerScripts : MonoBehaviour
{
    public static CubeSpawnerScripts Instance;
    public static int Spawner=4;
    public List<CubeScripts> cubeList = new List<CubeScripts>();
    public CubeScripts currentCube;
    public Transform spawnPoint;
    private UIManager _uýManager;

    public GameObject cow, duck, pig, goat,farm;
    public Image farmcolor;

    public static int SpawnerControl;
    private void Awake()
    {
        _uýManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (PlayerPrefs.HasKey("CuneCount") == false)
        {
            PlayerPrefs.SetInt("CuneCount", cubeList.Count);
        }
    }
    private void Start()
    {
        currentCube = PickRandomCube();
        //Spawner = 4;
        if (Spawner == 4)
        {
            farmcolor = farm.GetComponent<Image>();

            var tempColor = farmcolor.color;
            tempColor.a = 0.5f;
            farmcolor.color = tempColor;
            farm.GetComponent<Button>().interactable = false;
        }
        

    }
    private void Update()
    {
        newAnimalControl();
        
    }

    private void OnTriggerEnter(Collider other)
    {
            StartCoroutine(SetCube());          
    }
    private IEnumerator SetCube()
    {
            yield return new WaitForSeconds(0.75f);
            currentCube = PickRandomCube();          
    }
    private CubeScripts PickRandomCube()
    {
        GameObject temp = Instantiate(cubeList[Random.Range(0, Spawner)].gameObject, spawnPoint.position, Quaternion.Euler(-30,-180,0));
        return temp.GetComponent<CubeScripts>();
    }

    public void newAnimalControl()
    {
        
        if (Spawner == 4)
        {
            SpawnerControl = 4;
            cow.SetActive(true);
           
        }
        if (Spawner == 5)
        {
            SpawnerControl = 5;
            farmcolor = farm.GetComponent<Image>();

            var tempColor = farmcolor.color;
            tempColor.a = 1.0f;
            farmcolor.color = tempColor;
            farm.GetComponent<Button>().interactable = true;
            cow.SetActive(false);
            duck.SetActive(true);
            
        }
        if (Spawner == 6)
        {
            SpawnerControl = 6;
            duck.SetActive(false);
            pig.SetActive(true);
        }
        if (Spawner == 7)
        {
            SpawnerControl = 7;
            pig.SetActive(false);
            goat.SetActive(true);
        }
    }
   

}
