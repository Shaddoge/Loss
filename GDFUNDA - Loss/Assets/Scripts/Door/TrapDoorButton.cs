using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorButton : MonoBehaviour
{
    [SerializeField] private GameObject[] requiredTriggers;
    [SerializeField] private float openSpeed = 5.0f;
    [SerializeField] private float openRange = 5.0f;
    [SerializeField] private bool inverted = false;
    private float rangeCounter = 0.0f;
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
            if (!requiredTriggers[i].GetComponentInChildren<TriggerButton>().isActive)
            {
                isUnlocked = false;
            }
        }
        if (isUnlocked)
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
        if (rangeCounter < openRange)
        {
            rangeCounter += openSpeed * Time.deltaTime;
            if(!inverted)
                transform.position = initialPos + new Vector3(rangeCounter, 0f, 0f);
            else
                transform.position = initialPos - new Vector3(rangeCounter, 0f, 0f);
        }
    }

    void Close()
    {
        if (rangeCounter > 0.0f)
        {
            rangeCounter -= openSpeed * Time.deltaTime;
            if (!inverted)
                transform.position = initialPos + new Vector3(rangeCounter, 0f, 0f);
            else
                transform.position = initialPos - new Vector3(rangeCounter, 0f, 0f);
        }
    }
}
