using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform gun;
    [SerializeField] Transform firePoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Transform _bulletBox;


    // private Queue<Bullet> _bulletsPool;

    private void Awake()
    {
        // _bulletsPool = new Queue<Bullet>();
    }

    void Update()
    {
        AimGun();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    
    void AimGun()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-coordinate is 0 for 2D

        // Calculate the direction from the gun to the mouse
        Vector2 direction = (mousePosition - gun.position).normalized;

        // Calculate the angle to rotate the gun

        // Rotate the gun to face the mouse
        float angle;
        if (_player.transform.localScale.x == 1)
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, -30, 40);
        }
        else
        {
            angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, -30, 40);
        }
        
        
        if ((gun.rotation.z < -29 && angle > 39))
        {
            return;
        }
        else if( (gun.rotation.z > 39 && angle < -29))
        {
            return;
        }
        
        
        gun.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    
    void Shoot()
    {
        Bullet bullet;
        // if (_bulletsPool.Count != 0)
        // {
        //     bullet = _bulletsPool.Dequeue();
        // }
        // else
        // {
            bullet = Instantiate(_bulletPrefab, _bulletBox);
        // }

        bullet.transform.position = firePoint.position;
        bullet.SetGun(this);
        var rigidbody2DComponent = bullet.GetComponent<Rigidbody2D>();
        Debug.Log(transform.forward);
        rigidbody2DComponent.velocity = transform.right * _bulletSpeed * _player.transform.localScale.x;
    }

    // public void AddMeToPool(Bullet gb)
    // {
    //     _bulletsPool.Enqueue(gb);
    // }
}
