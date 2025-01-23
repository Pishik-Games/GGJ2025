using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private short _damage = 5;
    private Vector2 _direction;

    private void Awake()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this);
    }
}
