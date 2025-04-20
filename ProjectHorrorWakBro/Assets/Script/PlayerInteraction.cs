using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 4f;
    Interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        } 
    }

    void CheckInteraction() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if(hit.collider.tag == "Interactable") //if looking at an interactable object
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                // if there is a current interactable and is not the new Interactable
                if (currentInteractable && newInteractable != currentInteractable) 
                {
                    currentInteractable.DisableOutline();
                }
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable (newInteractable);
                }
                else // if new interactable is not enable
                {
                    DisableCurrentInteractable();
                }
            }
            else //if not an interactable
            {
                DisableCurrentInteractable();
            }
        }
        else // if not in the reach
        {
            DisableCurrentInteractable();
        }
    }
    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
    }

    void DisableCurrentInteractable()
    {
        if(currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable=null;
        }
    }
}
