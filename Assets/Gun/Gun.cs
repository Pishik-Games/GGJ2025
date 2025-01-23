using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private Bullet _bulletPrefab;


    private Queue<Bullet> _bulletsPool;
    public Transform firePoint;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
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
