using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    public float flySpeed;

    [Header("Yaw (Turn Left/Right)")]
    public float horizontalInput;
    public float yawMult;
    public float yaw;

    [Header("Pitch (Incline Up/Down)")]
    public float verticalInput;
    public float pitchMult;
    public float pitch;

    public float smoothRollVel;
    public float smoothRollTime;
    public float rollAngle;

    public void OnHorizontal(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<float>();
    }

    public void OnVertical(InputAction.CallbackContext context)
    {
        verticalInput = context.ReadValue<float>();
    }

    private void Update()
    {
        // Throttle (Forward)
        transform.position += flySpeed * Time.deltaTime * transform.forward;

        // Yaw (Turn Left - Right)
        Debug.Log($"Horizontal Input: {horizontalInput}");
        yaw += horizontalInput * yawMult * Time.deltaTime;

        // Pitch (Incline Up / Down)
        pitch += verticalInput * pitchMult * Time.deltaTime;

        // Roll
        float targetRoll = horizontalInput * rollAngle;
        float roll = Mathf.SmoothDampAngle(-transform.localRotation.eulerAngles.z, targetRoll, ref smoothRollVel, smoothRollTime);
        Debug.Log($"Roll: {roll}");

        transform.localRotation = Quaternion.Euler(yaw * Vector3.up + pitch * Vector3.right + roll * Vector3.back);
    }
}
