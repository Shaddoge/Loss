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
    // Update is called once per frame
    void Update()
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
}
