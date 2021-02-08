using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerv2 : MonoBehaviour
{
    public GameObject currentEnemyTarget;

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
        
    }

    void Update()
    {
        if (ReadyToShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (currentEnemyTarget != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform);
            bullet.GetComponent<Bullet>().SetTarget(currentEnemyTarget.transform);

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
}
