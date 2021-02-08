using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
   
    public int gameScore = 0;
    public int cash = 0;

    public float decreaseSpawnTime ;
    public float waitTimeToIncreaseDifficulty ;
    public int cashAmountToAdd ;
    public float waitTimeToIncreaseCash ;
    public static GameManager instance;

    void Start()
    {
        // TileMap.instance.GenerateMap();
        instance = this;
        StartCoroutine(IncreaseDifficulty(waitTimeToIncreaseDifficulty));
        StartCoroutine(IncreaseCash(waitTimeToIncreaseCash));

    }

    
    void Update()
    {
       
    }

    public void ScoreUp()
    {
        gameScore++;
    }  

    IEnumerator IncreaseDifficulty(float waitTime)
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnManager.instance.DecreaseSpawnTime(decreaseSpawnTime);
        }
    }

    IEnumerator IncreaseCash(float waitTime)
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            cash += cashAmountToAdd;
        }
    }

    public void DecreaseCash(int amount)
    {
        cash -= amount;
    }
}
