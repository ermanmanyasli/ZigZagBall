using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public bool gamePlaying;


    [SerializeField]
    private GameObject tile;
    private Vector3 currentTilePosition;
    private AudioSource gemCollectSound;

    [SerializeField]
    private Text scoreText;

    private int score = 0;

    void Awake()
    {
        gemCollectSound = GetComponent<AudioSource>();
        MakeSingleton();
        currentTilePosition = new Vector3(-2,0,2);
    }


    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            CreateTiles();
        }
    }


    private void OnDisable()
    {
        instance = null;
    }


    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void CreateTiles()
    {
        Vector3 newTilePosition = currentTilePosition;
        int rand = Random.Range(0,100);
        if (rand < 50)
        {
            newTilePosition.x -= 1f;
        }
        else
        {
            newTilePosition.z += 1f;
        }
        currentTilePosition = newTilePosition;
        Instantiate(tile, currentTilePosition, Quaternion.identity) ;
    }


    public void ActivateTileSpawner()
    {
        StartCoroutine(SpawnNewTiles());
    }



    IEnumerator SpawnNewTiles()
    {
        yield return new WaitForSeconds(0.3f);
        CreateTiles();

        if (gamePlaying)
        {
            StartCoroutine(SpawnNewTiles());
        }
    }


    public void PlayGemSound()
    {
        gemCollectSound.Play(); ;
    }


    public void IncreaseScore()
    {
        if (gamePlaying)
        {
            score++;
            print(score);
            scoreText.text = score.ToString();
        }
    }

} //class























