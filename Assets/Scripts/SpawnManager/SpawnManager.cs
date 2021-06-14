using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance;
    public GameObject enemyPrefab;
    public float minimumTimebetweenEnemies; //waits for the next enemy to spawn. 
    
    public Transform spawnPoint;   //enemy spawn point
    public int enemyLimit;     //total enemy allowed in the scene
    [SerializeField]
    private float decreaseRate;  //enemy spawn time decreases with this value. the more the faster the enemy will spawn
    [SerializeField]
    private float waitTime;   //the amount of time to be waited to increase the difficulty by decreasing spawn time
    private float initialWaitTime;

    void Start()
    {
        initialWaitTime = waitTime;
        instance = this;
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
       if(waitTime<=0)
        {
            IncreaseSpawnRate();
            waitTime = initialWaitTime;
        }
        
    }

    private void IncreaseSpawnRate()
    {
        minimumTimebetweenEnemies -= decreaseRate;
        minimumTimebetweenEnemies = Mathf.Clamp(minimumTimebetweenEnemies, 0.5f, 3.5f);
    }

    void SpawnEnemy()
    {
        if(EnemyPoolManager.instance.GetActiveEnemySize()<enemyLimit)
        {
            if (EnemyPoolManager.instance.CheckEnemyInPool())  //checks if any enemy is avaible which is destroyed once and ready to be reassign
            {
                GameObject enemy = EnemyPoolManager.instance.GetEnemyFromPool();
                enemy.transform.position = spawnPoint.position;
                enemy.transform.rotation = Quaternion.identity;             
                enemy.gameObject.SetActive(true);                           // if enemy available in pool. Uses it instead of creating a new gameObject
                EnemyPoolManager.instance.AddNewEnemyToActivePool(enemy);
            }
            else   
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); // if no enemies avaialbe in pool, creates a new enemyObject
                EnemyPoolManager.instance.AddNewEnemyToActivePool(enemy);
            }
        }
        else
        {
            Debug.Log("Max Enemy Limit Reached");
        }
       
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(minimumTimebetweenEnemies);
        }
       
    }

    

 
}
