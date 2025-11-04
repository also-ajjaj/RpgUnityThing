using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    public float speed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = new Vector2(0, 0);
        
        if (Input.GetKey(KeyCode.W))
        {
            _direction.y = 1;
        }else if (Input.GetKey(KeyCode.S))
        {
            _direction.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _direction.x = -1;
        }else if (Input.GetKey(KeyCode.D))
        {
            _direction.x = 1;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForce(_direction.normalized * (speed * Time.fixedDeltaTime));
    }
}
