using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorPlateTrigger : MonoBehaviour
{
    [SerializeField] private ObjectType triggerRequired;
    [SerializeField] private GameObject door;
    [SerializeField] private float height = 4.0f;
    [SerializeField] private float openSpeed = 2.0f;
    private float heightCounter = 0.0f;
    
    //Button Pressure
    private float pushHeight = 0.125f;
    private float pushTicks = 0.0f;

    int numColliding = 0;
    bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PickableObject>())
        {
            numColliding++;
            Debug.Log(numColliding);
            if (!isActive && triggerRequired == other.GetComponent<PickableObject>().objectType)
            {
                isActive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PickableObject>())
        {
            numColliding--;
            Debug.Log(numColliding);
            if (isActive && numColliding <= 0)
            {
                isActive = false;
            }
        }
    }

    private void Update()
    {
        if(isActive && pushTicks <= pushHeight)
        {
            pushTicks += Time.deltaTime;
            transform.position -= new Vector3(0f, Time.deltaTime, 0f);
        }
        else if(!isActive && pushTicks > 0f)
        {
            pushTicks -= Time.deltaTime;
            transform.position += new Vector3(0f, Time.deltaTime, 0f);
        }

        if(isActive && heightCounter < height)
        {
            heightCounter += openSpeed * Time.deltaTime;
            door.transform.position += new Vector3(0f, openSpeed * Time.deltaTime, 0f);
        }
        else if(!isActive && heightCounter > 0.0f)
        {
            heightCounter -= openSpeed * Time.deltaTime;
            door.transform.position -= new Vector3(0f, openSpeed * Time.deltaTime, 0f);
        }
    }

}
