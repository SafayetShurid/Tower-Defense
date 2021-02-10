using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuilderManager;

public class Tower : MonoBehaviour
{


    private List<GameObject> enmeyObjects;
    private GameObject currentEnemyTarget;
    private AudioSource bulletSound;

    [Header("Tower Property")]
    [SerializeField]
    private TowerType towerType;
    [SerializeField]
    private float range;
    [SerializeField]
    private float fireRate; //decides how many bullets a tower can shoot , the more the value the more the bullets
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int towerPrice;


    private float fireCountDown = 1f;



    void Start()
    {

        InvokeRepeating("FindEnemyObjects", 0.1f, 1f);  //keeps get called after 1 second to determine enemy targets
        InvokeRepeating("GetClosestTarget", 0.1f, 1f);  //Selects the nearest target to shoot
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
            if (Vector3.Distance(transform.position, currentEnemyTarget.transform.position) <= range)
            {
                GameObject bullet = Instantiate(bulletPrefab, this.transform);
                bullet.GetComponent<Bullet>().SetTarget(currentEnemyTarget.transform);

                //bulletSound.Play();


            }

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
                if (enemy != null)
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


    public int GetTowerPrice()
    {
        return towerPrice;
    }

    public GameObject GetBulletPrefab()
    {
        return bulletPrefab;
    }

    public TowerType GetTowerType()
    {
        return towerType;
    }


}
