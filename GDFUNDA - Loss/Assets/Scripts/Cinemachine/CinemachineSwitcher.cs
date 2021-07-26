using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator animator;
    private bool personCamera = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchState()
    {
        if(personCamera)
        {
            animator.Play("3rd Person Camera");
        }
        else
        {
            animator.Play("Head Camera");
        }
        personCamera = !personCamera;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchState();
        }
    }
}
