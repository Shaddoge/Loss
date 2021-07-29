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
    GameObject crosshair;
    [SerializeField] GameObject guide;

    private void Start()
    {
        crosshair = GameObject.Find("Crosshair");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>() && hit.transform.GetComponent<PickableObject>())
        {
            crosshair.GetComponent<Image>().color = new Color32(100, 255, 255, 255);
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.tag == "Interactable")
        {
            crosshair.GetComponent<Image>().color = new Color32(100, 255, 255, 255);
            guide.SetActive(true);
        }
        else
        {
            crosshair.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            guide.SetActive(false);
        }
        Grab();
        Interact();
    }

    private void Grab()
    {
        
        // Grabbing Objects
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>() && hit.transform.GetComponent<PickableObject>())
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
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.collider.tag == "Interactable")
        {
            if(hit.transform.gameObject.GetComponent<DoorButtonTrigger>())
            {
                hit.transform.gameObject.GetComponent<DoorButtonTrigger>().ButtonActive();
            }
        }
    }
}
