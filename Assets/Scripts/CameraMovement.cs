using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerModel;
    [SerializeField] private Transform orientation;

    [SerializeField] private float rotationSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandlePlayerOrentation();
    }

    private void HandlePlayerOrentation()
    {
        Vector3 viewDir = player.transform.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = orientation.forward * vertical + orientation.right * horizontal;

        if (inputDir != Vector3.zero)
        {
            playerModel.transform.forward = Vector3.Slerp(playerModel.transform.forward, inputDir.normalized, rotationSpeed * Time.deltaTime);
        }
    }
}
