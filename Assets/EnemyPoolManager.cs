using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{

    public int poolSize;

    Queue<GameObject> idleEnemyPoolObjects;
    List<GameObject> activeEnemyPoolObjects;

    public static EnemyPoolManager instance;

    void Start()
    {
        instance = this;
        idleEnemyPoolObjects = new Queue<GameObject>(poolSize);
        activeEnemyPoolObjects = new List<GameObject>(poolSize);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckEnemyInPool()
    {
        if (idleEnemyPoolObjects.Count > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddNewEnemyToPool(GameObject enemy)
    {
        if (activeEnemyPoolObjects.Count > poolSize)
        {
            Debug.Log("Pool size exceeded. Please incease size");
        }
        else
        {
            activeEnemyPoolObjects.Add(enemy);
        }
    }

    public void RemoveEnemyFromPool(GameObject enemy)
    {
         activeEnemyPoolObjects.Remove(enemy);      
    }

    public GameObject GetEnemyFromPool()
    {
        return idleEnemyPoolObjects.Dequeue();
    }

    public List<GameObject> GetActiveEnemies()
    {
        return activeEnemyPoolObjects;
    }
}
