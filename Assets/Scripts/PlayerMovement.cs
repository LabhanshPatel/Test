using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private Animator playerAnimator;


    void Update()
    {
        HandleMovement();

        HandleWalkCycle();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = orientation.forward * vertical + orientation.right * horizontal;

        transform.position += moveDir * speed * Time.deltaTime;
    }

    void HandleWalkCycle()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("walking", true);
        }
        else 
        {
            playerAnimator.SetBool("walking", false);
        }
    }
}
