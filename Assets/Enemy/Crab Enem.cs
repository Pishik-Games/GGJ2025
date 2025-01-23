using System;
using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    [SerializeField] private short speed;
    private Rigidbody2D _rigidbody2D;
    private short _direction;
    private short _health = 100;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction * speed, 0);

    }

    public void ChangeDirection()
    {
        _direction *= -1;
    }

    public void Damaged(short damage)
    {
        
    }
}
