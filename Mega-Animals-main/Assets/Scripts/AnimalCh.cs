using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimalCh : MonoBehaviour
{
    [SerializeField] HighScoreManager _gameManager;
    public int animalValue;
    public float eatValue = 5f;
    public Image fillImage;
    public GameObject Canvas;

    void Update()
    {

    }
    void OnMouseDown()
    {
        FarmManager.Instance.card.GetCard(animalValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy02"))
        {
            /*if (_gameManager.Puan >= 10)
            {
                StartCoroutine(SetCloseGameObject2());
                _gameManager.ScorManager2();
                _collider.material.dynamicFriction = daynanicMat;
                if (gameIndex == 1)
                {
                    _farmManager.HungerBar.fillAmount += 0.1f;
                }
            }*/

            if (_gameManager.Puan >= 10)
            {
                FarmManager.Instance.animals[animalValue].UpdateLevelXp(eatValue);
                StartCoroutine(FillCoroutine());
            }
            
            Destroy(collision.gameObject);

        }
    }
    IEnumerator FillCoroutine()
    {
        Canvas.SetActive(true);
        fillImage.fillAmount = FarmManager.Instance.animals[animalValue].totalXp / FarmManager.Instance.animals[animalValue].needXpForLevel[FarmManager.Instance.animals[animalValue].level];
        yield return new WaitForSeconds(1);
        Canvas.SetActive(false);


    }

}
