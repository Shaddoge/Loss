using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    //Should have DoorPlateTrigger Component
    [SerializeField] private GameObject[] requiredTriggers;
    [SerializeField] private float height = 4.0f;
    [SerializeField] private float openSpeed = 2.0f;
    private float heightCounter = 0.0f;
    Vector3 initialPos;
    bool isUnlocked = false;

    private void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isUnlocked = true;
        for (int i = 0; i < requiredTriggers.Length; i++)
        {
            if(!requiredTriggers[i].GetComponentInChildren<TriggerButton>().isActive)
            {
                isUnlocked = false;
            }
        }
        if(isUnlocked)
        {
            Open();
        }
        else
        {
            Close();
        }

    }

    void Open()
    {
        if (heightCounter < height)
        {
            heightCounter += openSpeed * Time.deltaTime;
            transform.position = initialPos + new Vector3(0f, heightCounter, 0f);
        }
    }

    void Close()
    {
        if (heightCounter > 0.0f)
        {
            heightCounter -= openSpeed * Time.deltaTime;
            transform.position = initialPos + new Vector3(0f, heightCounter, 0f);
        }
    }


}
