using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Tilemaps;


public class FishEnemy : MonoBehaviour
{
    [SerializeField] private short moveSpeed;
    [SerializeField] private LayerMask platformLayer; // Layer for platform tiles
    [SerializeField] private Tilemap platformTilemap; // Reference to the Tilemap containing platforms

    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _circleCollider2D;
    private Vector2 _direction;
    private short _health = 100;
    // private Player _player;
    private float distanceToPlayer;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }
    

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _direction * moveSpeed;

    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     _circleCollider2D.radius = 5;
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     _circleCollider2D.radius = 4;
    //     //change sprite to angry fish
    // }
    //
    // private void OnColliderStay2D(Collider2D other)
    // {
    //     distanceToPlayer = Vector2.Distance(transform.position, other.transform.position);
    //
    //
    //     if (!IsPlatformBetween(transform.position, other.transform.position))
    //     {
    //         // Move towards the player
    //         Vector2 direction = (other.transform.position - transform.position).normalized; 
    //         transform.Translate(direction * moveSpeed * Time.deltaTime);
    //     }
    // }
    //
    // private bool IsPlatformBetween(Vector2 start, Vector2 end)
    // {
    //     // Use Physics2D.Linecast to check for platforms
    //     RaycastHit2D hit = Physics2D.Linecast(start, end, platformLayer);
    //
    //     // If a platform is hit, return true
    //     if (hit.collider != null)
    //     {
    //         return true;
    //     }
    //
    //     // Alternatively, use Tilemap API to check for tiles along the path
    //     Vector2 currentPos = start;
    //     Vector2 direction = (end - start).normalized;
    //     float distance = Vector2.Distance(start, end);
    //
    //     for (float i = 0; i < distance; i += 0.1f)
    //     {
    //         currentPos = start + direction * i;
    //         Vector3Int cellPosition = platformTilemap.WorldToCell(currentPos);
    //
    //         if (platformTilemap.HasTile(cellPosition))
    //         {
    //             return true;
    //         }
    //     }
    //
    //     return false;
    // }
    //
    // public void ChangeDirection()
    // {
    //     if (_direction == Vector2.right || _direction == Vector2.left)
    //     {
    //         _direction *= -1;
    //     }
    // }
    //
    // public void Damaged(short damage)
    // {
    //     _health -= damage;
    //     if (_health < 1)
    //     {
    //         // GameManager.instance.AddScore(20)
    //     }
    // }
}
