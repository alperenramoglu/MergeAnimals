using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerScripts : MonoBehaviour
{
    public static CubeSpawnerScripts Instance;
    public static int Spawner;
    public List<CubeScripts> cubeList = new List<CubeScripts>();
    public CubeScripts currentCube;
    public Transform spawnPoint;
    private UIManager _u�Manager;

    private void Awake()
    {
        _u�Manager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (PlayerPrefs.HasKey("CuneCount") == false)
        {
            PlayerPrefs.SetInt("CuneCount", cubeList.Count);
        }
    }
    private void Start()
    {
        currentCube = PickRandomCube();
        Spawner = 4;

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
        GameObject temp = Instantiate(cubeList[Random.Range(0, Spawner)].gameObject, spawnPoint.position, Quaternion.Euler(0,-180,0));
        return temp.GetComponent<CubeScripts>();
    }
}
