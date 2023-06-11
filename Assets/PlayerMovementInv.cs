using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovementInv : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    private PlayerControlsInv playerControlsInv;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerControlsInv = new PlayerControlsInv();
    }

    private void OnEnable()
    {
        playerControlsInv?.Enable();
    }

    private void OnDisable()
    {
        playerControlsInv?.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(playerControlsInv.Player.MovementInv.ReadValue<Vector2>().x, 0, playerControlsInv.Player.MovementInv.ReadValue<Vector2>().y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
