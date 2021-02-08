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

    public bool normalTowerSelected;
    public bool powerfulTowerSelected;

    void Start()
    {
        instance = this;
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
