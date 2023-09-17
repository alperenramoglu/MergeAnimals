using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HungerManager : MonoBehaviour
{

    public Image HungerBar;
    public static float hunger;
    // Start is called before the first frame update
    void Start()
    {
        hunger = FarmManager.hunger;
        HungerBar.fillAmount = hunger;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        HungerBar.fillAmount -= 1.0f / 200 * Time.deltaTime;
        
    }
}
