using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    public float gameTime = 0f;

    void Start()
    {
        //TileMap.instance.GenerateMap();
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if(gameTime%5==0)
        {
            Debug.Log("OK");
        }
    }
}
