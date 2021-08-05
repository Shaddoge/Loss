using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResetPressurePlate : MonoBehaviour
{
    [SerializeField] GameObject[] targetPressurePlates;

    public void ResetPlate()
    {
        for (int i = 0; i < targetPressurePlates.Length; i++)
        {
            if (targetPressurePlates[i].GetComponentInChildren<TriggerPressurePlate>())
            {
                targetPressurePlates[i].GetComponentInChildren<TriggerPressurePlate>().isActive = false;
            }
        }
    }
}
