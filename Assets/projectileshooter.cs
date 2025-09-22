using UnityEngine;
using System.Collections;

/// <summary>
/// This script continuously fires projectiles from a specified point.
/// Attach this script to the object that should be shooting.
/// </summary>
public class ProjectileShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    [Tooltip("The projectile GameObject to be fired. This must be a prefab.")]
    public GameObject projectilePrefab;

    [Tooltip("The transform where the projectile will be spawned.")]
    public Transform firePoint;

    [Header("Firing Mechanics")]
    [Tooltip("The number of projectiles to fire per second.")]
    public float fireRate = 5f;

    // Internal timer to manage the firing rate
    private float nextFireTime = 0f;

    /// <summary>
    /// This method is called once per frame.
    /// </summary>
    void Update()
    {
        // Continuously check if enough time has passed to fire the next projectile.
        if (Time.time >= nextFireTime)
        {
            Shoot();
            // Set the time for the next shot based on the fire rate.
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    /// <summary>
    /// Instantiates and fires a projectile.
    /// </summary>
    void Shoot()
    {
        // Make sure both the prefab and the fire point have been assigned in the Inspector.
        if (projectilePrefab != null && firePoint != null)
        {
            // Create a new projectile instance at the fire point's position and rotation.
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            // Log a warning to the console if something is not set up correctly.
            Debug.LogWarning("Projectile Prefab or Fire Point is not assigned.", this);
        }
    }
}

