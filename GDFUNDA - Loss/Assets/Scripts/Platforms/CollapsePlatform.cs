using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsePlatform : MonoBehaviour
{
    [SerializeField] private float crumbleTimer = 2.0f;
    [SerializeField] private float resetTimer = 3.0f;
    private bool isTouched = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isTouched && other.tag == "Player")
        {
            isTouched = true;
            this.StartCoroutine(this.StartTimer());
        }
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(crumbleTimer);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(resetTimer);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<MeshCollider>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;

        isTouched = false;
    }
}
