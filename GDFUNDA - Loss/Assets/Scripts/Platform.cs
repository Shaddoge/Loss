using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float delay = 0.2f;
    [SerializeField] private float speed = 1.0f;
    private float delay_ticks = 0.0f;
    private float ticks = 0.0f;
    private bool isReverse = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        delay_ticks += Time.deltaTime;
        if (delay_ticks >= delay)
        {
            ticks += Time.deltaTime;
            if (!isReverse)
                this.transform.position = Vector3.Lerp(start.position, end.position, ticks);
                //rb.MovePosition(Vector3.Lerp(start.position, end.position, ticks));
            else
                this.transform.position = Vector3.Lerp(end.position, start.position, ticks);
                //rb.MovePosition(Vector3.Lerp(end.position, start.position, ticks));

            if (ticks >= 1.0f)
            {
                ticks = 0.0f;
                delay_ticks = 0.0f;
                isReverse = !isReverse;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = this.transform;
        Debug.Log("Enter");
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<CharacterController>().SimpleMove(rb.velocity);
    //        Debug.Log("Move");
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
        Debug.Log("Exit");
    }
}
