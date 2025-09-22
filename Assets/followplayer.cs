using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField] Transform player;
    private Vector3 playerPosition;

    void Start()
    {
        playerPosition = player.transform.position;
    }

    void Update()
    {
        MoveToPlayer();
        DestroyOnHit();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, (speed * Time.deltaTime));
    }

    private void DestroyOnHit()
    {
        if (transform.position == playerPosition)
        {
            Destroy(gameObject);
        }
    }
}