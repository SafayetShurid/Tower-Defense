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
        if(UiManager.instance.IfAnyButtonSelected())
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
       
        if (UiManager.instance.IfAnyButtonSelected())
        {
            BuilderManager.instance.BuildTower(transform);
        }

    }
}
