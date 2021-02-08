using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Color hoverColor;
    public SpriteRenderer spriteRenderer;
    public Transform tileCenterPosition;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(UiManager.instance.powerfulTowerSelected || UiManager.instance.normalTowerSelected)
        {
            spriteRenderer.color = hoverColor;
        }    
       
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }

    private void OnMouseUpAsButton()
    {
       
        if (UiManager.instance.powerfulTowerSelected || UiManager.instance.normalTowerSelected)
        {
            BuilderManager.instance.BuildTower(transform);
        }

    }
}
