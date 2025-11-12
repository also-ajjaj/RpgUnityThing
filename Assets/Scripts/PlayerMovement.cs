using System;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    private SpriteAnimator _spriteAnimator;
    public float speed;
    public Direction lastDirection =  Direction.Down;

    private void Awake()
    {
        _spriteAnimator = GetComponent<SpriteAnimator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = new Vector2(0, 0);
        
        
        if (Input.GetKey(KeyCode.W))
        {
            _direction.y = 1;
            lastDirection = Direction.Up;
        }else if (Input.GetKey(KeyCode.S))
        {
            _direction.y = -1;
            lastDirection = Direction.Down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _direction.x = -1;
            lastDirection = Direction.Left;
        }else if (Input.GetKey(KeyCode.D))
        {
            _direction.x = 1;
            lastDirection = Direction.Right;
        }

        if (_direction != Vector2.zero)
        {
            switch (lastDirection)
            {
                case Direction.Up:
                    _spriteAnimator.PlayAnimation("WalkUp");
                    break;
                case Direction.Down:
                    _spriteAnimator.PlayAnimation("WalkDown");
                    break;
                case Direction.Left:
                    _spriteAnimator.PlayAnimation("WalkLeft");
                    break;
                case Direction.Right:
                    _spriteAnimator.PlayAnimation("WalkRight");
                    break;
            }
        }
        else
        {
            switch (lastDirection)
            {
                case Direction.Up:
                    _spriteAnimator.PlayAnimation("IdleUp");
                    return;
                case Direction.Down:
                    _spriteAnimator.PlayAnimation("IdleDown");
                    return;
                case Direction.Left:
                    _spriteAnimator.PlayAnimation("IdleLeft");
                    return;
                case Direction.Right:
                    _spriteAnimator.PlayAnimation("IdleRight");
                    return;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForce(_direction.normalized * (speed * Time.fixedDeltaTime));
    }
}
