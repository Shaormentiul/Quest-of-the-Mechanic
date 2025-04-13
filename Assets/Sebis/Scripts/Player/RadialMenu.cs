using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    public Transform center;
    public Transform selectObject;

    public GameObject RadialMenuRoot;

    bool isRadialMenuActive;
    void Start()
    {
        isRadialMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            isRadialMenuActive = !isRadialMenuActive;
            if(isRadialMenuActive)
            {
                RadialMenuRoot.SetActive(true);
            }
            else
            {
                RadialMenuRoot.SetActive(false);
            }
        }

        if(isRadialMenuActive)
        {
            //Formula for calculating angle
            Vector2 delta = center.position = Input.mousePosition;
            float angle = Mathf.Atan2(delta.y, delta.x) + Mathf.Rad2Deg;

            for(int i = 0 ; i < 360 ; i += 45)
            {
                if(angle >= i && angle < i + 45)
                {
                    selectObject.eulerAngles = new Vector3(0, 0, i);
                }
            }
        }
    }
}
