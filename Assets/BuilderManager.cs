using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{
    public GameObject normalTowerPrefab;
    public GameObject powerfulTowerPrefab;

    public static BuilderManager instance;


    public enum TowerType { normal,powerful}

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
            GameManager.instance.DecreaseCash(powerfulTowerPrefab.GetComponent<Tower>().GetTowerPrice());
        }
        else
        {
            towerObject = Instantiate(normalTowerPrefab, tilePosition);
            GameManager.instance.DecreaseCash(normalTowerPrefab.GetComponent<Tower>().GetTowerPrice());

        }
       
        towerObject.transform.position += new Vector3(0.5f, 0.5f,0f);
        UiManager.instance.normalTowerSelected = false;
        UiManager.instance.powerfulTowerSelected = false;
    }

    public GameObject GetTowerPrefab(TowerType towerType)
    {
        switch(towerType)
        {
            case TowerType.normal:
                return normalTowerPrefab;                
            case TowerType.powerful:
                return powerfulTowerPrefab;
            default:
                return null;
        }
    }
}
