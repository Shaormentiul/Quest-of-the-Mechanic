using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbChoose : Interactable
{
    public SceneSelect scener;
    public int index;
    public GameObject portal;
    public GameObject otherPortal;

    protected override void Interact()
    {
        scener.selectedSceneIndex = index;
        portal.SetActive(true);
        otherPortal.SetActive(false);

    }   
}
