using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 20f;

    [Header("Borders")]
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRangeMin = 5f;
    [SerializeField] private float yRangeMax = 5f;

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
        float rawPositionX = transform.localPosition.x + xOffset;
        float clampedPositionX = Mathf.Clamp(rawPositionX, -xRange, xRange);

        float yOffset = moveInput.y * controlSpeed * Time.deltaTime;
        float rawPositionY = transform.localPosition.y + yOffset;
        float clampedPositionY = Mathf.Clamp(rawPositionY, yRangeMin, yRangeMax);

        transform.localPosition = new Vector3(clampedPositionX, clampedPositionY, transform.localPosition.z);
    }
}
