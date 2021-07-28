using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{

    [SerializeField] private Transform playerCamera;
    private Transform player;

    bool isPickable = false;
    bool isCarried = false;
    bool isColliding = false;

    // Start is called before the first frame update
    private void OnEnable()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // If player is within the range
        if(dist <= 2.5f)
        {
            isPickable = true;
        }
        else
        {
            isPickable = false;
        }

        if (isPickable && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCamera;
            isCarried = true;
        }
        if(isCarried)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("What");
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isCarried = false;
                isColliding = false;
            }
            if(isColliding)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                //transform.parent = null;
                //isCarried = false;
                isColliding = false;
            }
            else
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
        if(isCarried)
        {
            isColliding = true;
        }
    }

}
