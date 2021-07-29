using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction { X, Z };

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Direction direction;
    [SerializeField] private float timeSwitch = 10.0f;
    [SerializeField] private float speed = 2.0f;

    private float ticks = 0.0f;
    private bool isReverse = false;

    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    public Vector3 lastPosition;
    Transform _transform;

    private void Start()
    {
        _transform = transform;
        lastPosition = _transform.position;
    }

    private void LateUpdate()
    {
        if (rigidbodies.Count > 0)
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                Rigidbody rb = rigidbodies[i];
                Vector3 velocity = (_transform.position - lastPosition);
                rb.transform.Translate(velocity, _transform);
            }
        }
        lastPosition = _transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        ticks += Time.deltaTime;
        if (ticks > timeSwitch)
        {
            isReverse = !isReverse;
            ticks = 0.0f;
        }

        if (direction == Direction.X)
        {
            switch(isReverse)
            {
                case false: gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f); break;
                case true: gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f); break;
            }
        }

        else if (direction == Direction.Z)
        {
            switch (isReverse)
            {
                case false: gameObject.transform.position += new Vector3(0f, 0f, speed * Time.deltaTime); break;
                case true: gameObject.transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime); break;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Debug.Log("Touch");
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
            other.transform.localPosition = Vector3.up * 1.1f;
        }

        if (rb != null)
        {
            Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }

        if (rb != null)
        {
            Remove(rb);
        }
    }

    void Add(Rigidbody rb)
    {
        if (!rigidbodies.Contains(rb))
            rigidbodies.Add(rb);
    }

    void Remove(Rigidbody rb)
    {
        if (rigidbodies.Contains(rb))
            rigidbodies.Remove(rb);
    }

}
