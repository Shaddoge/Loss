using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemInstance : MonoBehaviour
{
    private static EventSystemInstance instance = null;
    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
        else
            DestroyEventSystemDuplicate();
    }

    private void DestroyEventSystemDuplicate()
    {
        Destroy(this.gameObject);
    }
}
