using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDamageRecognizer : MonoBehaviour
{
    // private FishEnemy _parentCrabEnemy;
    //
    // private void Awake()
    // {
    //     _parentCrabEnemy = GetComponentInParent<FishEnemy>();
    // }
    //
    // private void OnTriggerEnter2D(Collision2D other)
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
}
