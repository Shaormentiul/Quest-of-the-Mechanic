using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private ShadowItem shadow;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; 
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                if(hitInfo.collider.GetComponent<ShadowItem>())
                {   
                    shadow =  hitInfo.collider.GetComponent<ShadowItem>();
                    shadow.Shadow();
                }
                else if(shadow != null)
                {
                    shadow.ShadowNoMore();
                    shadow = null;
                }
                   
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
        else
        {
            if(shadow != null)
            {
                shadow.ShadowNoMore();
                shadow = null;
            }
            
        }
    }
}
