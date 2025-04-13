using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerButton : Interactable
{
    public float fillGraphValue;
    public bool isFilling;
    public float speed;
    public float maxFill;
    public float startingFill;
    public bool needsToFill;
    public bool needsToUnfill;
    public bool isAtMax;
    public bool isAtBottom;

    public Renderer rendy;
    Material matty;
    


    void Start()
    {
        matty = rendy.material;
    }    

    void Update()
    {
        matty.SetFloat("_Fill", fillGraphValue);

        if(fillGraphValue <= maxFill && needsToFill && !isAtMax && isAtBottom)
        {
            Debug.Log("filling");
            fillGraphValue += speed * Time.deltaTime;
        }

        else if(fillGraphValue >= maxFill && isAtBottom) 
        {
            fillGraphValue = maxFill;
            needsToFill = false;
            isAtMax = true;
            isAtBottom = false;
        }

        if(fillGraphValue >= -maxFill && needsToUnfill && isAtMax && !isAtBottom)
        {
            Debug.Log("unfilling");
            fillGraphValue -= speed * Time.deltaTime;
        }

        else if(fillGraphValue <= -maxFill && isAtMax) 
        {
            fillGraphValue = -1;
            needsToUnfill = false;
            isAtMax = false;
            isAtBottom = true;
        }

    }

    protected override void Interact()
    {
        if(isAtBottom)
        needsToFill = true;
        else if(isAtMax)
        needsToUnfill = true;
    }
}
