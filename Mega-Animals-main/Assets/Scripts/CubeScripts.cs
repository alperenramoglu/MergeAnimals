using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CubeScripts : MonoBehaviour
{
    static int staticID = 0;
    [HideInInspector] public int CubeID;
    [HideInInspector] public Color CubeColor;
    [HideInInspector] public int CubeNumber;
    public Rigidbody CubeRigidbody;
    [HideInInspector] public bool IsMainCube;

    public int value;

    [SerializeField] HighScoreManager _gameManager;
    [SerializeField] FarmManager _farmManager;

    [SerializeField] ParticleSystem _particleSystem, _particleSystemF, _particleSystemWALL;

    private Collider _collider;
    private float daynanicMat = 1f;

    public SpriteRenderer _sprite;

    [SerializeField] AudioClip _Clip;

    private float time = 0.8f;


    

    private void Awake()
    {
        CubeID = staticID++;
        _collider = GetComponent<Collider>();
        CubeRigidbody = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("HighScoreManager").GetComponent<HighScoreManager>();
        _farmManager = GameObject.Find("FarmManager").GetComponent<FarmManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float b = 0;
        if (collision.gameObject.CompareTag("enemy01"))
        {         
            if (collision.gameObject.TryGetComponent(out CubeScripts cube))
            {
                if (cube.value == value && this.CubeID > cube.CubeID)
                {
                    CubeRigidbody.AddForce(transform.up * 350);
                    StartCoroutine(SetCloseGameObject());
                    if (Time.time >= b+time)
                    {
                        if (cube.value == HighScoreManager.animalControl)
                        {
                            if (_gameManager.newAnimalPuan >= 16)
                            {
                                cube.transform.DOScale(cube.transform.localScale / 4, 0.7f);
                                cube.transform.DOMove(_gameManager.effectRefPoint.position, 1f).OnComplete(() => Destroy(cube.gameObject));
                            }
                            else
                            {
                                Destroy(cube.gameObject);
                            }
                            _gameManager.birdScore();

                        }
                        else
                        {
                            Destroy(cube.gameObject);
                        }
                        b = Time.time;

                        _gameManager.ScorManager();

                    }                   
                    _collider.material.dynamicFriction = daynanicMat;
                    SoundManager.Instance.PlaySound(_Clip);
                }
            }
        }
        if (collision.gameObject.CompareTag("enemy02"))
        {
            if(_gameManager.Puan >= 10)
            {
                StartCoroutine(SetCloseGameObject2());
                _gameManager.ScorManager2();
                _collider.material.dynamicFriction = daynanicMat;
                _farmManager.HungerBar.fillAmount += 0.1f;
            }
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("enemy03"))
        {
            if (_gameManager.Puan >= 10)
            {
                _collider.enabled = false;
                _particleSystem = Instantiate(_particleSystemWALL, gameObject.transform.position, Quaternion.identity);
                _gameManager.ScorManager2();
            }

            Destroy(gameObject,0.6f);

        }
       }
    private void Update()
    {
        if (CubeRigidbody.velocity.magnitude == 0)
        {
            _sprite.color = new Color(r: 1f, g: 1f, b: 1f, a: 0f);
        }
        else
        {
            _sprite.color = new Color(r: 1f, g: 1f, b: 1f, a: 0.1f);
        }
    }
    public IEnumerator SetCloseGameObject()
    {
        _particleSystem = Instantiate(_particleSystem, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
        
    }
    public IEnumerator SetCloseGameObject2()
    {
        _particleSystem = Instantiate(_particleSystemF, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        //Destroy(this.gameObject);

    }
}
