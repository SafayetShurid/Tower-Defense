using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance;
    public GameObject enemyPrefab;
    public float minimumTimebetweenEnemies;
    public float minimumTimebetweenWaves;
    public Transform spawnPoint;

    void Start()
    {
        instance = this;
        StartCoroutine(StartSpawning(minimumTimebetweenEnemies));
    }

    // Update is called once per frame
    void Update()
    {
       
        
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

    IEnumerator StartSpawning(float minimumTimebetweenEnemies)
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(minimumTimebetweenEnemies);
        }
       
    }

    public void DecreaseSpawnTime(float decreaseTime)
    {
        minimumTimebetweenWaves -= decreaseTime;
    }

 
}
