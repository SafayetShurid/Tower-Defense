using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance;
    public GameObject enemyPrefab;
    public float minimumTimebetweenEnemies;
    
    public Transform spawnPoint;

    [SerializeField]
    private float decreaseRate;
    [SerializeField]
    private float waitTime;
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
    }

    void SpawnEnemy()
    {
        if(EnemyPoolManager.instance.CheckEnemyInPool())
        {
            GameObject enemy = EnemyPoolManager.instance.GetEnemyFromPool();
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = Quaternion.identity;                     
            enemy.gameObject.SetActive(true);
            EnemyPoolManager.instance.AddNewEnemyToActivePool(enemy);
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            EnemyPoolManager.instance.AddNewEnemyToActivePool(enemy);
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
