using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private Transform grabPosition;
    [SerializeField] private float strength = 1.0f;
    RaycastHit hit;
    GameObject grabbedObject;

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>() && hit.transform.GetComponent<PickableObject>())
        {
            Grab();
            EventBroadcaster.Instance.PostEvent(EventNames.UI_Events.PICKABLE_IN_RANGE);
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.transform.GetComponent<TriggerButton>())
        {
            Interact();
            EventBroadcaster.Instance.PostEvent(EventNames.UI_Events.BUTTON_IN_RANGE);
        }
        else
        {
            EventBroadcaster.Instance.PostEvent(EventNames.UI_Events.OUT_OF_RANGE);
        }
    }

    private void Grab()
    {
        
        // Grabbing Objects
        if (Input.GetMouseButtonDown(0))
        {
            if(strength >= hit.transform.GetComponent<Rigidbody>().mass)
            {
                grabbedObject = hit.transform.gameObject;
            }
                
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(grabbedObject != null)
            {
                grabbedObject = null;
            }
        }
        if (grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = 10 * (grabPosition.position - grabbedObject.transform.position);
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(hit.transform.gameObject.GetComponent<TriggerButton>())
            {
                hit.transform.gameObject.GetComponent<TriggerButton>().ButtonActive();
            }
        }
    }
}
