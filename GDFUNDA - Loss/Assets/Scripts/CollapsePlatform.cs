using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsePlatform : MonoBehaviour
{
    private bool isTouched = false;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        if (!isTouched)
        {
            isTouched = true;
            this.StartCoroutine(this.StartTimer());
        }
            
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(1.0f);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;

        isTouched = false;
    }
}
