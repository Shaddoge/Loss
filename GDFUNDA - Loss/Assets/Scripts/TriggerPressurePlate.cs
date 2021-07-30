using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerPressurePlate : MonoBehaviour
{
    [SerializeField] private ObjectType triggerRequired;

    //Button Pressure
    private float pushHeight = 0.125f;
    private float pushTicks = 0.0f;

    int numColliding = 0;
    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PickableObject>())
        {
            numColliding++;
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
    }
}
