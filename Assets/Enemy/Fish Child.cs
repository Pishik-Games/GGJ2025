using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDamageRecognizer : MonoBehaviour
{
    private FishEnemy _parentCrabEnemy;

    private void Awake()
    {
        _parentCrabEnemy = GetComponentInParent<FishEnemy>();
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.GetComponent<Player>() != null)
    //     {
    //         // damage player
    //     }
    //     else if (other.gameObject.GetComponent<Bullet>() != null)
    //     {
    //         _parentCrabEnemy.Damaged(5);
    //     }
    //     else
    //     {
    //         _parentCrabEnemy.ChangeDirection();
    //     }
    // }
}
