using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform gun;
    [SerializeField] Transform firePoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Player _player;


    private Queue<Bullet> _bulletsPool;

    
    void Update()
    {
        AimGun();
        if (Input.GetMouseButtonDown(1))
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the gun to face the mouse
        if (_player.transform.localScale.x == 1)
        {
            angle = Mathf.Clamp(angle, 30, 150);
        }
        else
        {
            angle = Mathf.Clamp(angle, -30, -150);
        }
        gun.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    
    void Shoot()
    {
        Bullet bullet;
        if (_bulletsPool.Peek())
        {
            bullet = _bulletsPool.Dequeue();
        }
        else
        {
            bullet = Instantiate(_bulletPrefab, transform);
        }
        var rigidbody2DComponent = bullet.GetComponent<Rigidbody2D>();
        rigidbody2DComponent.AddForce(firePoint.forward * 10, ForceMode2D.Impulse);
    }}
