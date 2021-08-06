using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessObject : MonoBehaviour
{
    private static GameObject owner = null;
    // Start is called before the first frame update
    private void Start()
    {
        if (!owner)
            owner = this.gameObject;
        else
            Destroy(this.gameObject);
    }
}
