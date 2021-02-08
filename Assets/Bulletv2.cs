using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletv2 : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Transform target;
    private Vector3 targetDirection;
    private float distancePerFrame;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsEnemy();
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
        target.GetComponent<Enemy>().health -= 10;
    }
}
