using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrigger : MonoBehaviour
{
    [SerializeField] private GameObject stateDrivenCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            stateDrivenCamera.GetComponent<CinemachineSwitcher>().SwitchState();
            Destroy(gameObject);
        }
    }
}
