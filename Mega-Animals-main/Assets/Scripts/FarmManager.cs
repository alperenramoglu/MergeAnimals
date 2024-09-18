using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class FarmManager : MonoBehaviour
{
    private static FarmManager instance;

    public static FarmManager Instance { get { return instance; } }

    public GameObject cow, duck, pig, goat, farm;
    //public GameObject[] animals;
    public Animal[] animals;
    public Card card;

    public Image farmcolor;
    public Image HungerBar;
    public int spawn;
    //public static int score;
    public static float hunger;


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

    }

    void Start()
    {
        CubeSpawnerScripts.SpawnerControl = 5;
        //score = HighScoreManager.score;
        hunger = HungerManager.hunger;
        HungerBar.fillAmount = hunger;
        UpdateAnimalLevels();
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
        //score = HighScoreManager.score;
        HungerBar.fillAmount -= 1.0f/200 * Time.deltaTime;
        hunger = HungerBar.fillAmount;
        for (int i = 0; i <= spawn-5; i++)
        {
            animals[spawn - 5].animalObject.SetActive(true);
        }

        /*if (spawn == 5)
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
        }*/
    }

    public void CloseCard()
    {
        card.cardObject.transform.DOScale(Vector3.zero, 0.3f).OnComplete(() => card.cardPanel.SetActive(false));
        
    }

    public void UpdateAnimalLevels()
    {
        for (int i = 0; i < HighScoreManager.Instance.animalLevels.Length; i++)
        {
            HighScoreManager.Instance.animalLevels[i] = animals[i].level;
        }
    }

    [System.Serializable]
    public class Animal
    {
        public string name;
        public GameObject animalObject;
        public int level;
        public float totalXp;
        public Sprite sprite;
        public float[] needXpForLevel;

        public void UpdateLevelXp(float xp)
        {
            totalXp += xp;
            if (totalXp >= needXpForLevel[level] )
            {
                level += 1;
                Debug.Log(level);
                FarmManager.Instance.UpdateAnimalLevels();
            }
            Debug.Log(name + " " + totalXp);
        }

    }

    [System.Serializable]
    public class Card
    {

        public GameObject cardObject;
        public GameObject cardPanel;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI levelText;
        public Image chImage;
        public Image fillImage;
        public GameObject[] skills;


        public void GetCard(int animalValue)
        {
            int levelThis = FarmManager.Instance.animals[animalValue].level;
            cardPanel.active = true;
            cardObject.transform.localScale = Vector3.zero;
            cardObject.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
            nameText.text = FarmManager.Instance.animals[animalValue].name;
            levelText.text = levelThis.ToString(); ;
            chImage.sprite = FarmManager.Instance.animals[animalValue].sprite;
            fillImage.fillAmount = FarmManager.Instance.animals[animalValue].totalXp / FarmManager.Instance.animals[animalValue].needXpForLevel[FarmManager.Instance.animals[animalValue].level];

            for (int i = 0; i < 3; i++)
            {
                if(i < levelThis)
                {
                    skills[i].SetActive(false);
                }
                else
                {
                    skills[i].SetActive(true);
                }
            }

            /*for (int i = 1; i <= FarmManager.Instance.animals[animalValue].level; i++)
            {
                if (i > 4)
                {
                    break;
                }
                skills[i - 1].SetActive(false);
            }*/
        }

        
    }
}
