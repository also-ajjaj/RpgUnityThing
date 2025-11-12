using System;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Start()
    {
        if (target != null)
        {
            Vector3 startPosition = target.position; 
            startPosition.z = -10f;
            transform.position = startPosition;;
        }
        else
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
}
