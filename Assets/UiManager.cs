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

    public Text gameOverText;

    public bool normalTowerSelected;
    public bool powerfulTowerSelected;

    private Tower normalTower;
    private Tower powerfulTower;

    void Start()
    {
        instance = this;
        normalTower = BuilderManager.instance.GetTowerPrefab(BuilderManager.TowerType.normal).GetComponent<Tower>();
        powerfulTower = BuilderManager.instance.GetTowerPrefab(BuilderManager.TowerType.powerful).GetComponent<Tower>();
        SetTowerShopUI();
    }

    

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.gameScore.ToString();
        cashText.text = GameManager.instance.cash.ToString() + "$";

        if(GameManager.instance.cash< normalTower.GetTowerPrice())
        {
            normalTowerButton.interactable = false;
        }
        else
        {
            normalTowerButton.interactable = true;
        }
        if (GameManager.instance.cash < powerfulTower.GetTowerPrice())
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

    private void SetTowerShopUI()
    {
       
        normalTowerCashText.text = normalTower.GetTowerPrice().ToString() + "$";
        normalTowerBulletText.text = normalTower.GetBulletPrefab().GetComponent<Bullet>().GetBulletDamage().ToString() + "/s";

       
        powerfulTowerCashText.text = powerfulTower.GetTowerPrice().ToString() + "$";
        powerfulTowerBulletText.text = powerfulTower.GetBulletPrefab().GetComponent<Bullet>().GetBulletDamage().ToString() + "/s";
    }

    public void showGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }


}
