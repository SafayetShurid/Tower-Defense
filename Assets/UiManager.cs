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

    public Button normalTowerButton;
    public Button powerfulTowerButton;

    public Text normalTowerCashText;
    public Text powerfulTowerCashText;

    public Text normalTowerBulletText;
    public Text powerfulTowerBulletText;

    public bool normalTowerSelected;
    public bool powerfulTowerSelected;

    void Start()
    {
        instance = this;
        SetTowerShopUI();
    }

    private void SetTowerShopUI()
    {
        GameObject nomralTower = BuilderManager.instance.GetTowerPrefab(BuilderManager.TowerType.normal);
        normalTowerCashText.text = nomralTower.GetComponent<Tower>().GetTowerPrice().ToString() + "$";
        normalTowerBulletText.text = nomralTower.GetComponent<Tower>().GetBulletPrefab().ToString()  + "$";

        GameObject powerfulTower = BuilderManager.instance.GetTowerPrefab(BuilderManager.TowerType.powerful);
        powerfulTowerCashText.text = powerfulTower.GetComponent<Tower>().GetTowerPrice().ToString() + "$";
        powerfulTowerBulletText.text = powerfulTower.GetComponent<Tower>().GetBulletPrefab().ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.gameScore.ToString();
        cashText.text = GameManager.instance.cash.ToString() + "$";

        if(GameManager.instance.cash<15)
        {
            normalTowerButton.interactable = false;
        }
        else
        {
            normalTowerButton.interactable = true;
        }
        if (GameManager.instance.cash < 35)
        {
            powerfulTowerButton.interactable = false;
        }
        else
        {
            powerfulTowerButton.interactable = true;
        }
    }

    public void SelectNormalTower()
    {
        normalTowerSelected = true;
        powerfulTowerSelected = false;
    }

    public void SelectPowerfulTower()
    {
        powerfulTowerSelected = true;
        normalTowerSelected = false;
    }


}
