using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private float height = 4.0f;
    [SerializeField] private float openSpeed = 2.0f;
    private float heightCounter = 0.0f;

    int numColliding = 0;
    bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        numColliding++;
        if(!isActive)
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        numColliding--;
        if(isActive && numColliding <= 0)
        {
            isActive = false;
        }
    }

    private void Update()
    {
        if(isActive && heightCounter < height)
        {
            heightCounter += openSpeed * Time.deltaTime;
            door.transform.position += new Vector3(0f, openSpeed * Time.deltaTime, 0f);
        }
        else if(heightCounter > 0.0f)
        {
            heightCounter -= openSpeed * Time.deltaTime;
            door.transform.position -= new Vector3(0f, openSpeed * Time.deltaTime, 0f);
        }
    }

}
