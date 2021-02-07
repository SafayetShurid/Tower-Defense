using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public List<GameObject> enmeyObjects;
   
    public GameObject currentEnemyTarget;

    [Header("Tower Property")]
    [SerializeField]
    private float range;
    [SerializeField]
    private float fireRate ;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int bulletPoolSize;
    private Queue<GameObject> bulletPool;
    private float fireCountDown = 1f; 
    


    void Start()
    {
        bulletPool = new Queue<GameObject>(bulletPoolSize);
        //InvokeRepeating("FindEnemyObjects", 0.1f,2.1f);
        //InvokeRepeating("GetClosestTarget", 0.1f, 2.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(ReadyToShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
       if(bulletPool.Count>0)
        {
            GameObject bullet = bulletPool.Dequeue();
        }
       else
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform);
        }
    }

    private bool ReadyToShoot()
    {
        fireCountDown -= Time.deltaTime;
       if(fireCountDown<=0f)
        {
            fireCountDown = 1 / fireRate;
            return true;
        }
       else
        {
            return false;
        }
    }

    private void FindEnemyObjects()
    {
        enmeyObjects = EnemyPoolManager.instance.GetActiveEnemies();     
    }

    private void GetClosestTarget()
    {
        if (enmeyObjects.Count <= 0)
        {
            return;
        }
        else
        {
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enmeyObjects)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                currentEnemyTarget = nearestEnemy;
            }
            else
            {
                nearestEnemy = null;
            }
        }
        
    }

    

}
