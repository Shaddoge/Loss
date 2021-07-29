using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private float height = 4.0f;
    [SerializeField] private float openSpeed = 2.0f;
    [SerializeField] private float timer = 0.0f;
    private float heightCounter = 0.0f;

    bool isActive = false;
    float ticks = 0.0f;

    public void ButtonActive()
    {
        if(heightCounter <= 0.0f)
        {
            isActive = true;
        }
    }

    public void ButtonInactive()
    {
        isActive = false;
    }

    private void Update()
    {
        if(timer > 0.0f && isActive)
        {
            ticks += Time.deltaTime;
            if (ticks >= timer)
            {
                isActive = false;
                ticks = 0.0f;
            }
        }
        

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
