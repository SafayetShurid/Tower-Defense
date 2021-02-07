using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    public float speed =1;
  
   
    [Header("Destination Variables")]
    private GameObject destinationPointParent;    
    private List<Transform> destinationPoints;
    private int targetIndex = 0;
    private Transform target;

    private void Awake()
    {
        SetDestinationPoints();
    }


    void Start()
    {
        target = destinationPoints[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Move();        
    }





   

    private void Move()
    {
        if (targetIndex < destinationPoints.Count)
        {
            target = destinationPoints[targetIndex];
            if (!DestinationReached())
            {
                MoveTowardsDestination();               
            }
            else
            {
                SetTargetToNextDestination();
            }

        }
    }

    #region Destination
    private bool DestinationReached()
    {
        return Vector2.Distance(transform.position, target.position) < Mathf.Epsilon;
    }

    private void MoveTowardsDestination()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void SetTargetToNextDestination()
    {
        targetIndex++;
    }

    private void SetDestinationPoints()
    {
        destinationPointParent = GameObject.Find("DestinationPoints");
        destinationPoints = new List<Transform>(destinationPointParent.transform.childCount);

        for (int i = 0; i < destinationPoints.Capacity; i++)
        {
            destinationPoints.Add(destinationPointParent.transform.GetChild(i));
        }

    }
    #endregion
}
