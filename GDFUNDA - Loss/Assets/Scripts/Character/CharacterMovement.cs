using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpHeight = 2.0f;

    [Header("Ground detection")]
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private LayerMask groundMask;

    private Camera cam;
    private Character character;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isPushing;
    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        EventBroadcaster.Instance.AddObserver(EventNames.Player_Events.IS_PUSHING_STATE, this.PushingState);
        EventBroadcaster.Instance.AddObserver(EventNames.Player_Events.IS_NORMAL_STATE, this.NormalState);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Player_Events.IS_PUSHING_STATE);
    }

    private void PushingState()
    {
        Debug.Log("Character is Pushing State");
        isPushing = true;
    }

    private void NormalState()
    {
        Debug.Log("Character is Normal State");
        isPushing = false;
    }

    // Update is called once per frame
    private void Update()
    {
        bool isGrounded = Physics.CheckSphere(transform.position + Vector3.down, groundDistance, groundMask);

        if (velocity.y < 0.0f && isGrounded)
            velocity.y = 0.0f;


        Vector3 dir = cam.transform.forward * Input.GetAxis("Vertical") + cam.transform.right * Input.GetAxis("Horizontal") * (isPushing ? 0:1) ;
        dir = Vector3.ProjectOnPlane(dir, Vector3.up);
        controller.Move(dir * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && (character.GetState() & CharacterState.Legs) != 0 && !isPushing)
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
        
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        if(isPushing)
        {
            cam.GetComponent<CameraMovement>().LockYaw();
        }
        else
        {
            cam.GetComponent<CameraMovement>().UnlockYaw();
        }
    }
}
