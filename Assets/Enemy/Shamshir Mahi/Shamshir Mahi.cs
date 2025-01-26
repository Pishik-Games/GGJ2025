using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShamshirMahi : MonoBehaviour
{
    [SerializeField] private short _moveSpeed;
    [SerializeField] private short _attackSpeed;
    // [SerializeField] private Player _player;
    [SerializeField] private float _normalHeight;
    [SerializeField] private GameObject _bubble;



    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxTrigger2D;
    private SpriteRenderer _eyeSpriteRenderer;
    private Vector2 _direction;
    private short _health = 200;
    private float distanceToPlayer;
    private int _targetPointIndex;
    private int _round;
    private short _currentSpeed;
    private CapsuleCollider2D _capsuleCollider2D;



    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxTrigger2D = GetComponent<BoxCollider2D>();
        _eyeSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _direction = Vector2.right;
        _targetPointIndex = 0;
        _currentSpeed = _moveSpeed;
    }
    

    private void FixedUpdate()
    {

        _rigidbody2D.velocity = _direction * _currentSpeed;



    }

    public void ChangeDirection()
    {
        _direction *= -1;
        transform.eulerAngles = new Vector3(0, 180 - transform.eulerAngles.y, 0);
        // _targetPointIndex = 1 - _targetPointIndex;
        _round++;
        if (_round == 1)
        {
            _currentSpeed = _moveSpeed;
            StartCoroutine(HeightAnimation(_normalHeight));
        }
        else if (_round == 2)
        {
            _currentSpeed = _attackSpeed;
            StartCoroutine(HeightAnimation(-1 * _normalHeight));
            _round = 0;
        }
    }

    public void Damaged(short damage)
    {
        _health -= damage;
        if (_health < 1)
        {
            // GameManager.instance.AddScore(20)
            _direction = transform.up * 2;
            _bubble.SetActive(true);
            _capsuleCollider2D.enabled = false;
            StartCoroutine(Wait());

        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("message from " + gameObject + ": im in OnCollisionEnter2D");
        if (other.gameObject.tag == "Player")
        {
            // damage player
        }
        else if (other.gameObject.tag == "Bullet")
        {
            Damaged(20);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") return;
        ChangeDirection();
        Debug.Log("message from " + gameObject + ": im in OnTriggerEnter2D");
    }

    IEnumerator HeightAnimation(float nH)
    {
        nH /= 20;
        for (int i = 0; i < 20; i++)
        {
            transform.position += new Vector3(0, nH, 0);
            yield return new WaitForSeconds(0.03f);
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
