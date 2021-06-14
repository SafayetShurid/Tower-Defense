using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;

    public Text scoreText;
    public Text cashText;

    public Button[] towerBuyButtons;
    public Text[] priceTexts;
    public Text[] bulletTexts;

    public bool[] whichTowerSelected; //determines the index which button is currently selected

    private GameObject[] totalTowerObjects;

    public Text gameOverText;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalTowerObjects = BuilderManager.instance.GetTowerList();
        SetTowerShopUI();             
        InvokeRepeating("CheckButtonInteractablity", 0f, 0.5f);   //checks which button is available to click depending on cash

    }

    void Update()
    {
        scoreText.text = GameManager.instance.gameScore.ToString();
        cashText.text = GameManager.instance.cash.ToString() + "$";   
        
      
    }
    
    public void CheckButtonInteractablity()
    {
        for( int i= 0; i<totalTowerObjects.Length; i++)
        {
            if (GameManager.instance.cash < totalTowerObjects[i].GetComponent<Tower>().GetTowerPrice())
            {
                towerBuyButtons[i].interactable = false;
            }
            else
            {
                towerBuyButtons[i].interactable = true;
            }
        }
    }

    public void SelectTower(int value)
    {
        for (int i = 0; i < totalTowerObjects.Length; i++)
        {
            if(i ==value)
            {
                whichTowerSelected[i] = true;
            }
            else
            {
                whichTowerSelected[i] = false;
            }
        }
    }

    private void SetTowerShopUI()
    {
        
        for (int i = 0; i < totalTowerObjects.Length; i++)
        {
            priceTexts[i].text = totalTowerObjects[i].GetComponent<Tower>().GetTowerPrice().ToString() + "$";
            bulletTexts[i].text = totalTowerObjects[i].GetComponent<Tower>().GetBulletPrefab().GetComponent<Bullet>().GetBulletDamage().ToString() + "/s";
        }
       
    }

    public void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public int ReturnSelectedButtonIndex()
    {
        for (int i = 0; i < totalTowerObjects.Length; i++)
        {
            if(whichTowerSelected[i]==true)
            {
                return i;
            }
        }

        return 0;
    }

    public bool IfAnyButtonSelected()
    {
        for (int i = 0; i < totalTowerObjects.Length; i++)
        {
            if (whichTowerSelected[i] == true)
            {
                return true;
            }
        }

        return false;
    }

    public void SetButtonSelectedValues(bool state)
    {
        for (int i = 0; i < whichTowerSelected.Length; i++)
        {
            whichTowerSelected[i] = state;
        }

    }


}
