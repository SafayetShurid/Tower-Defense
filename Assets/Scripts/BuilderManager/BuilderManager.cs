using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{
    

    public GameObject[] towers;  //Holds the tower to build

    public static BuilderManager instance;

    public enum TowerType { normal,powerful}  //Add a tower type here whenever a new type is introduced

    private void Awake()
    {
        instance = this;
       
    }
   
    void Update()
    {
        
    }

    public void BuildTower(Transform tilePosition)  
    {
        GameObject towerObject = null;

        if (UiManager.instance.IfAnyButtonSelected())
        {
            towerObject = Instantiate(towers[UiManager.instance.ReturnSelectedButtonIndex()], tilePosition);
            GameManager.instance.DecreaseCash(towerObject.GetComponent<Tower>().GetTowerPrice());
        }
       
       
        towerObject.transform.position += new Vector3(0.5f, 0.5f,0f);
        tilePosition.GetComponent<BoxCollider2D>().enabled = false;  //makes the tile unclicable when a tower is placed
        UiManager.instance.SetButtonSelectedValues(false); //Sets all the buttons selected values to false
    }

    public GameObject GetTowerPrefab(TowerType towerType)
    {
       foreach(GameObject tower in towers)
        {
            if(tower.GetComponent<Tower>().GetTowerType().Equals(towerType))
            {
                return tower;
            }
            
        }
        return null;
    }

    public GameObject[] GetTowerList()
    {
        return towers;
    }
}
