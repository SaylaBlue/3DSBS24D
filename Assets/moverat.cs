using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [SerializeField] private Vector3 firstPosition = new Vector3(-48f, 48.4f, -5f);
    [SerializeField] private Vector3 secondPosition = new Vector3(-52f, 48.4f, -46f);
    private Vector3 target;

    public float speed = 10f;

    void Start()
    {
        transform.position = firstPosition;
        target = secondPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (transform.position == firstPosition)
        {
            target = secondPosition;
        }
        else if (transform.position == secondPosition)
        {
            target = firstPosition;
        }
    }
}
