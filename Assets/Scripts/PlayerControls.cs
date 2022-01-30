using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 20f;

    [Header("Borders")]
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 7f;

    [Header("Rotation")]
    [SerializeField] private float positionPitchFactor = -2f;
    [SerializeField] private float controlPitchFactor = -10f;
    [SerializeField] private float positionYawFactor = 2f;
    [SerializeField] private float controlRollFactor = 20f;

    [Header("Particles")]
    [SerializeField] private GameObject[] lasers;

    private Vector2 moveInput;
    private bool isFiring;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessTranslation()
    {
        float xOffset = moveInput.x * controlSpeed * Time.deltaTime;
        float rawPositionX = transform.localPosition.x + xOffset;
        float clampedPositionX = Mathf.Clamp(rawPositionX, -xRange, xRange);

        float yOffset = moveInput.y * controlSpeed * Time.deltaTime;
        float rawPositionY = transform.localPosition.y + yOffset;
        float clampedPositionY = Mathf.Clamp(rawPositionY, -yRange, yRange);

        transform.localPosition = new Vector3(clampedPositionX, clampedPositionY, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = moveInput.y * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = moveInput.x * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (isFiring)
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }

    private void ActivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    private void DeactivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}
