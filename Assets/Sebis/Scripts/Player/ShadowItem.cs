using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowItem : MonoBehaviour
{
    public GameObject shadow;

    public void Shadow()
    {
        shadow.SetActive(true);
    }

    public void ShadowNoMore()
    {
        shadow.SetActive(false);
    }
}
