using UnityEngine;

/// <summary>
/// This script defines the behavior of the projectile.
/// Attach this script to your projectile prefab.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("The forward speed of the projectile.")]
    public float speed = 25f;

    [Header("Lifetime")]
    [Tooltip("How many seconds the projectile will exist before being destroyed automatically.")]
    public float lifeTime = 5f;

    /// <summary>
    /// This method is called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        // Get the Rigidbody component attached to this projectile.
        Rigidbody rb = GetComponent<Rigidbody>();

        // Propel the projectile forward using its Rigidbody velocity.
        rb.linearVelocity = transform.forward * speed;

        // Schedule the projectile to be destroyed after its lifetime expires.
        // This prevents the scene from getting cluttered with old projectiles.
        Destroy(gameObject, lifeTime);
    }

    /// <summary>
    /// This method is called when this collider/rigidbody has begun touching another rigidbody/collider.
    /// </summary>
    /// <param name="collision">The collision data associated with this collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        // When the projectile hits something, destroy the object it hit.
        // You might want to add tags to filter what can be destroyed,
        // e.g., if(collision.gameObject.CompareTag("Enemy"))
        Destroy(collision.gameObject);

        // After hitting something, destroy the projectile itself.
        Destroy(gameObject);
    }
}
