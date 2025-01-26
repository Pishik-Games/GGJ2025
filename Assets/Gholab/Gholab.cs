using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gholab : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _down;
    [SerializeField] private Player _player;
    [SerializeField] private Transform playerTransformPosition;


    private Rigidbody2D _rigidbody2D;
    private int _direction;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (_down)
        {
            _player.CanMove(false);
            _direction = -1;
            StartCoroutine(MoveAnimation());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_down)
        {
            _direction = 1;
            _player.CanMove(false);
            StartCoroutine(MoveAnimation());   
        }
    }

    IEnumerator MoveAnimation()
    {
        for (int i = 0; i < 60; i++)
        {
            transform.position += new Vector3(0, _speed * _direction, 0);
            // _player.transform.position += new Vector3(0, _speed * _direction, 0);
            yield return new WaitForSeconds(0.05f);
        }
        enabled = false;
        _player.transform.SetParent(null);
        _player.GetComponent<Rigidbody2D>().isKinematic = false;
        _player.CanMove(true);


    }
}
