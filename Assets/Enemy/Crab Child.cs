using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabDamageRecognizer : MonoBehaviour
{
    private CrabEnemy _parentCrabEnemy;
    private void Awake()
    {
        _parentCrabEnemy = GetComponentInParent<CrabEnemy>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            // damage player
        }
        else if (other.gameObject.GetComponent<Bullet>() != null)
        {
            _parentCrabEnemy.Damaged(5);
        }
        else
        {
            _parentCrabEnemy.ChangeDirection();
        }
    }
}
