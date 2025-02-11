using System.Collections;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] private short _moveSpeed;
    [SerializeField] private Sprite _angryEye;
    [SerializeField] private Sprite _normalEye;
    [SerializeField] private bool _withEdge;
    [SerializeField] private GameObject _bubble;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _eyeSpriteRenderer;
    private Vector2 _direction;
    private short _health = 80;
    private CapsuleCollider2D _capsuleCollider2D;

    private bool _up;
    // private Player _player;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _eyeSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _direction = Vector2.right;
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        if (_withEdge)
        {
            boxCollider2D.offset = new Vector2(boxCollider2D.offset.x, -0.3f);
   
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _direction * _moveSpeed;

    }
    
    public void ChangeDirection()
    {
        _direction *= -1; 
        transform.eulerAngles = new Vector3(0,180 - transform.eulerAngles.y,0);
        
    }
    
    public void Damaged(short damage)
    {
        _health -= damage;
        if (_health < 1)
        {
            _direction = transform.up * 4;
            _bubble.SetActive(true);
            _capsuleCollider2D.enabled = false;
            _up = true;
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
            // Debug.Log("I Got Damage");
            Damaged(20);
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (_up)
        {
            return;
        }
        if (!_withEdge)
        {
            if (other.tag == "Player") return;
            Debug.Log("message from " + gameObject + ": im in OnTriggerExit2D");
            ChangeDirection();   
        }
    }
    //
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_up)
        {
            return;
        }
        if (_withEdge)
        {
            if (other.tag == "Player") return;
            Debug.Log("message from " + gameObject + ": im in OnTriggerExit2D");
            ChangeDirection();   
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
