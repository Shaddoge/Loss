using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private Transform grabPosition;

    private Character character;
    RaycastHit hit;
    GameObject grabbedObject;
    GameObject pushingObject;

    private void Start()
    {
        character = this.gameObject.GetComponentInParent<Character>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.transform.GetComponent<Rigidbody>() && hit.transform.tag == "Pickable" &&
            character.GetState().HasFlag(CharacterState.LeftArm))
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Guide_Events.PICKABLE_IN_RANGE);
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.transform.GetComponent<TriggerButton>())
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Guide_Events.BUTTON_IN_RANGE);
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, 2) && hit.transform.tag == "Pushable" &&
            character.GetState().HasFlag(CharacterState.Arms))
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Guide_Events.PUSHABLE_IN_RANGE);
        }
        else
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Guide_Events.OUT_OF_RANGE);
        }
        Grab();
        Interact();
        Push();
    }

    private void Grab()
    {
        // Grabbing Objects
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.transform.GetComponent<Rigidbody>() && hit.transform.tag == "Pickable" &&
            character.GetState().HasFlag(CharacterState.LeftArm))
        {
            grabbedObject = hit.transform.gameObject; 
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
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out hit, 3) && hit.transform.GetComponent<TriggerButton>())
        {
            if(hit.transform.gameObject.GetComponent<TriggerButton>())
            {
                hit.transform.gameObject.GetComponent<TriggerButton>().PressButton();
            }
        }
    }

    private void Push()
    {
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 2) && hit.transform.tag == "Pushable" &&
            character.GetState().HasFlag(CharacterState.Arms))
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Player_Events.IS_PUSHING_STATE);
            pushingObject = hit.transform.gameObject;
            pushingObject.transform.parent = this.transform.parent;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Player_Events.IS_NORMAL_STATE);
            if (pushingObject != null)
            {
                pushingObject.transform.parent = null;
            }
        }
    }
}
