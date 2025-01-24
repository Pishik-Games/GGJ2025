using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private short _damage = 5;
    private Gun _gun;
    private Vector2 _direction;

    private void Awake()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SetGun(Gun g)
    {
        _gun = g;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
        // _gun.AddMeToPool(this);
    }
    
}
