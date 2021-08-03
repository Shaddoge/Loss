using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    [SerializeField] private float timer = 0.0f;

    //Button Pressure
    private bool isPressed = false;
    private float pushHeight = 0.03125f;
    private float pushTicks = 0.0f;

    [HideInInspector] public bool isActive = false;
    float ticks = 0.0f;

    Vector3 initialPos;

    private void Start()
    {
        initialPos = this.transform.localPosition;
    }

    public void PressButton()
    {
        if (!isActive)
        {
            isActive = true;
            isPressed = true;
            if (timer > 0.0f)
            {
                this.StartCoroutine(this.StartTimer());
            }
        }
        
    }

    private void Update()
    {
        if (!isActive && pushTicks >= pushHeight)
        {
            isPressed = false;
        }
        if (isPressed && pushTicks <= pushHeight)
        {
            pushTicks += Time.deltaTime;
            transform.localPosition = initialPos - new Vector3(0f, pushTicks, 0f);
        }
        else if (!isPressed && pushTicks > 0f)
        {
            pushTicks -= Time.deltaTime;
            transform.localPosition = initialPos - new Vector3(0f, pushTicks, 0f);
        }

        if (timer > 0.0f && isActive)
        {
            ticks += Time.deltaTime;
            if (ticks >= timer)
            {
                isActive = false;
                ticks = 0.0f;
            }
        }
    }

    

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timer);
        isActive = false;
    }

}
