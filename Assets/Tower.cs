using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public List<GameObject> enmeyObjects;


    void Start()
    {
        InvokeRepeating("FindEnemyObjects", 0.1f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FindEnemyObjects()
    {
        //GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        enmeyObjects = EnemyPoolManager.instance.GetActiveEnemies();

       
    }

}
