using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLightSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] targetLights;
    
    private TriggerButton button;

    private void Start()
    {
        if (gameObject.GetComponentInChildren<TriggerButton>())
        {
            button = gameObject.GetComponentInChildren<TriggerButton>();
        }
    }

    private void Update()
    {
        if(button.isActive)
        {
            for (int i = 0; i < targetLights.Length; i++)
            {
                Light lightSource = targetLights[i].GetComponentInChildren<Light>();
                lightSource.enabled = !lightSource.enabled;
            }
            button.isActive = !button.isActive;
        }
    }
}
