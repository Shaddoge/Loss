using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    [SerializeField] private float sensitivityX = 100.0f;
    [SerializeField] private float sensitivityY = 100.0f;

    [SerializeField] private Transform grabPosition;
    RaycastHit hit;
    GameObject grabbedObject;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        if (Mathf.Abs(yaw) > 360.0f)
            yaw = 0.0f;

        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

        transform.rotation = Quaternion.Euler(new Vector3(pitch, yaw, 0.0f));

        if(Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        {
            grabbedObject = hit.transform.gameObject;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            grabbedObject = null;
        }
        if(grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = 10 * (grabPosition.position - grabbedObject.transform.position);
        }
    }
}
