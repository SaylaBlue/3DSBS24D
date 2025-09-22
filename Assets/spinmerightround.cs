using UnityEngine;

/// <summary>
/// Continuously rotates the GameObject this script is attached to.
/// </summary>
public class spinmerightround : MonoBehaviour
{
    // Define the rotation speed for each axis.
    // You can change these values in the Unity Inspector to control the speed and direction of rotation.
    // A positive value spins it one way, a negative value spins it the opposite way.
    [Header("Rotation Speed (Degrees per Second)")]
    [Tooltip("How fast to spin around the X axis.")]
    public float rotationSpeedX = 0f;

    [Tooltip("How fast to spin around the Y axis.")]
    public float rotationSpeedY = 50f;

    [Tooltip("How fast to spin around the Z axis.")]
    public float rotationSpeedZ = 0f;

    /// <summary>
    /// This method is called once per frame.
    /// </summary>
    void Update()
    {
        // Create a Vector3 to hold the rotation values for this frame.
        // We multiply the speed by Time.deltaTime to make the rotation smooth and
        // independent of the frame rate. This ensures the object rotates at a
        // consistent speed regardless of how fast the computer is.
        Vector3 rotationThisFrame = new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime;

        // Apply the rotation to the object's transform.
        // Space.World makes it rotate around the world axes, while Space.Self
        // would make it rotate around its own local axes.
        transform.Rotate(rotationThisFrame, Space.World);
    }
}
