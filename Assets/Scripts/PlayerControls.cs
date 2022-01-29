using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 20f;

    private Vector2 moveInput;

    private void Update()
    {
        PlayerMove();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void PlayerMove()
    {
        float xOffset = moveInput.x * controlSpeed * Time.deltaTime;
        float newPositionX = transform.localPosition.x + xOffset;

        float yOffset = moveInput.y * controlSpeed * Time.deltaTime;
        float newPositionY = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newPositionX, newPositionY, transform.localPosition.z);
    }
}
