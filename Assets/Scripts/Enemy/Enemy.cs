using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    private float speed; //how fasts enemy moves
    [SerializeField]
    private int health;  //enemy total health set to 100 by deafult
    [SerializeField]
    private int cashReward;  //cash amount received when an enemy dies

    [Header("HealthBar Variables")]
    [SerializeField]
    private Sprite[] healthBarSprites;  //healthbar UI
    [SerializeField]
    private SpriteRenderer healthBar;  


    [Header("Destination Variables")]
    private GameObject destinationPointParent;    
    private List<Transform> destinationPoints;
    private int targetIndex = 0;
    private Transform target;


    private void Awake()
    {
        SetDestinationPoints();  //Sets the DestinationPoint for the enemy to move
    }

    private void OnEnable()  //It gets called when the enemy is avaiable again to spawn
    {
        health = 100;     //sets the health back to 100
        UpdateHealthUI();   
        targetIndex = 0;  //sets the target destination to be the first point of the DestinationPoints
    }

    void Start()
    {
        target = destinationPoints[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Move();  //Moves the enemy from position to position and checks if it has reached final position. If reached then GameOVer
        CheckHealth();  //Checks the enemy health. If below 0 health it gets killed

    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
           
            GameManager.instance.ScoreUp();
            GameManager.instance.IncreaseCash(cashReward);
            this.gameObject.transform.position = SpawnManager.instance.spawnPoint.position;
            EnemyPoolManager.instance.AddNewEnemyToIdlePool(this.gameObject);
            EnemyPoolManager.instance.RemoveEnemyFromPool(this.gameObject);
            this.gameObject.SetActive(false);

        }
    }

    private void UpdateHealthUI()
    {
        if(health/10< 0 || health/10 >10)
        {
            return;
        }
        else
        {
            healthBar.sprite = healthBarSprites[health / 10];
        }    
        
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
        else
        {
            Debug.Log("Game Over");
            UiManager.instance.ShowGameOverText();
            Time.timeScale = 0f;
        }    
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthUI();
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
