using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectTimer : MonoBehaviour
{
    [SerializeField] private float timer = 6.0f;

    private void Start()
    {
        StartCoroutine(DestroyAfterTimer());
    }

    IEnumerator DestroyAfterTimer()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
