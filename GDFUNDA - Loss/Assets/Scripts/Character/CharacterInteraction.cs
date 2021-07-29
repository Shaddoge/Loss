using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private Transform grabPosition;
    [SerializeField] private float strength = 1.0f;
    RaycastHit hit;
    GameObject grabbedObject;

    // Update is called once per frame
    private void Update()
    {
        Grab();
        Interact();
    }

    private void Grab()
    {
        // Grabbing Objects
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>() && hit.collider.tag == "Pickable")
        {
            if(strength >= hit.transform.GetComponent<Rigidbody>().mass)
                grabbedObject = hit.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabbedObject = null;
        }
        if (grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = 10 * (grabPosition.position - grabbedObject.transform.position);
        }
    }

    private void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.tag == "Interactable")
        {
            if(hit.transform.gameObject.GetComponent<DoorButtonTrigger>())
            {
                hit.transform.gameObject.GetComponent<DoorButtonTrigger>().ButtonActive();
            }
        }
    }

}
