using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{
    public GameObject normalTowerPrefab;
    public GameObject powerfulTowerPrefab;

    public static BuilderManager instance;

    void Start()
    {
        instance = this;
    }

   
    void Update()
    {
        
    }

    public void BuildTower(Transform tilePosition)
    {
        GameObject towerObject = null;
        if (UiManager.instance.powerfulTowerSelected)
        {
            towerObject = Instantiate(powerfulTowerPrefab, tilePosition);
            GameManager.instance.DecreaseCash(35);
        }
        else
        {
            towerObject = Instantiate(normalTowerPrefab, tilePosition);
            GameManager.instance.DecreaseCash(15);

        }
       
        towerObject.transform.position += new Vector3(0.5f, 0.5f,0f);
        UiManager.instance.normalTowerSelected = false;
        UiManager.instance.powerfulTowerSelected = false;
    }
}
