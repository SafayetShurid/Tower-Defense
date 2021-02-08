using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int bulletDamage;
    private Transform target;
    private Vector3 targetDirection;
    private float distancePerFrame;
 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target==null || !target.gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            CalculateDistance();

            if (EnemyHit())
            {
                DealDamage();
                Destroy(gameObject);
            }
            else
            {
               
                MoveTowardsEnemy();
            }
          
        }

     
    }

    private bool EnemyHit()
    {
        if (targetDirection.magnitude <= distancePerFrame)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void CalculateDistance()
    {
        targetDirection = target.position - transform.position + new Vector3(0.5f, 0.5f);
        distancePerFrame = speed * Time.deltaTime;
    }

    private void MoveTowardsEnemy()
    {        
        transform.Translate(targetDirection.normalized * distancePerFrame, Space.World);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void DealDamage()
    {
        target.GetComponent<Enemy>().TakeDamage(bulletDamage);
    }
}
