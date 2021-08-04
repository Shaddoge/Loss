using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class DepthOfFieldController : MonoBehaviour
{
    [SerializeField] private float focusDistance = 100.0f;
    [SerializeField] private float focusSpeed = 1.0f;
    private Ray raycast;
    private RaycastHit hit;
    private float hitDistance = 0.0f;
    private bool isHit = false;

    public PostProcessVolume volume;
    private DepthOfField DOF;
    // Start is called before the first frame update
    private void Start()
    {
        volume.profile.TryGetSettings<DepthOfField>(out DOF);
    }

    // Update is called once per frame
    private void Update()
    {
        raycast = new Ray(transform.position, transform.forward * focusDistance);
        isHit = false;
        if (Physics.Raycast(raycast, out hit, focusDistance))
        {
            hitDistance = Vector3.Distance(transform.position, hit.point);
            isHit = true;
            Debug.Log($"Hit: {hitDistance}");
        }
        else
        {
            if (hitDistance < focusDistance)
                hitDistance++;
        }
        SetFocus();
    }

    private void SetFocus()
    {
        DOF.focusDistance.value = Mathf.Lerp(DOF.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
    }

    private void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.DrawSphere(hit.point, 0.1f);
            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));
        }
        else
            Debug.DrawRay(transform.position, transform.forward * focusDistance);
    }
}
