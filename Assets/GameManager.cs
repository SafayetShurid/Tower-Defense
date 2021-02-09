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
    public int cashAmountToAdd ;
    public float cashIncreaseSecond ;
    public static GameManager instance;

    void Start()
    {
        // TileMap.instance.GenerateMap();
        instance = this;
       
        StartCoroutine(FixedCashIncrease());

    }

    
    void Update()
    {
       
    }

    public void ScoreUp()
    {
        gameScore++;
    }  

    IEnumerator FixedCashIncrease()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            yield return new WaitForSeconds(cashIncreaseSecond);
            cash += cashAmountToAdd;
        }
    }

    public void IncreaseCash(int amount)
    {
        cash += amount;
    }

    public void DecreaseCash(int amount)
    {
        cash -= amount;
    }


}
