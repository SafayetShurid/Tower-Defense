using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public List<GameObject> enmeyObjects;

    public GameObject currentEnemyTarget;
    public AudioSource bulletSound;

    [Header("Tower Property")]
    [SerializeField]
    private float range;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]


    private float fireCountDown = 1f;



    void Start()
    {

        InvokeRepeating("FindEnemyObjects", 0.1f, 1f);
        InvokeRepeating("GetClosestTarget", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ReadyToShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (currentEnemyTarget != null && currentEnemyTarget.gameObject.activeInHierarchy)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform);
            bullet.GetComponent<Bullet>().SetTarget(currentEnemyTarget.transform);
            bulletSound.Play();


        }

    }

    private bool ReadyToShoot()
    {
        fireCountDown -= Time.deltaTime;
        if (fireCountDown <= 0f)
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
        enmeyObjects = new List<GameObject>();
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
                if(enemy!=null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
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
