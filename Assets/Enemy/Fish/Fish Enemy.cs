using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FishEnemy : MonoBehaviour
{
    [SerializeField] private short _moveSpeed;
    [SerializeField] private LayerMask platformLayer; // Layer for platform tiles
    [SerializeField] private Tilemap platformTilemap; // Reference to the Tilemap containing platforms
    [SerializeField] private GameObject _bubble;


    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxTrigger2D;
    private SpriteRenderer _eyeSpriteRenderer;
    private Animator _animator;
    private Vector2 _direction;
    private short _health = 40;
    // private Player _player;
    private CapsuleCollider2D _capsuleCollider2D;

    private float distanceToPlayer;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxTrigger2D = GetComponent<BoxCollider2D>();
        _eyeSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _direction = Vector2.right;
    }
    

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _direction * _moveSpeed;

    }
    
    public void ChangeDirection()
    {
        if (_direction == Vector2.right || _direction == Vector2.left)
        {
            _direction *= -1;
            transform.eulerAngles = new Vector3(0,180 - transform.eulerAngles.y,0);
        }
    }
    
    public void Damaged(short damage)
    {
        _health -= damage;
        if (_health < 1)
        {
            _direction = transform.up * 2;
            _bubble.SetActive(true);
            _capsuleCollider2D.enabled = false;
            StartCoroutine(Wait());        }
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
        else
        {
            ChangeDirection();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        Debug.Log("message from " + gameObject + ": im in OnTriggerEnter2D");
        _boxTrigger2D.size = new Vector2(9,7);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        _animator.SetTrigger("Normal");
        Debug.Log("message from " + gameObject + ": im in OnTriggerExit2D");
        _boxTrigger2D.size = new Vector2(7,5);
        //change sprite to angry fish
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        Debug.Log("message from " + gameObject + ": im in OnColliderStay2D");
        distanceToPlayer = Vector2.Distance(transform.position, other.transform.position);
    
    
        if (!IsPlatformBetween(transform.position, other.transform.position))
        {
            _animator.SetTrigger("Angry");
            // Move towards the player
            Vector2 direction = (other.transform.position - transform.position).normalized; 
            transform.Translate(direction * _moveSpeed * Time.deltaTime);
        }
    }
    
    private bool IsPlatformBetween(Vector2 start, Vector2 end)
    {
        // Use Physics2D.Linecast to check for platforms
        RaycastHit2D hit = Physics2D.Linecast(start, end, platformLayer);
    
        // If a platform is hit, return true
        if (hit.collider != null)
        {
            return true;
        }
    
        // Alternatively, use Tilemap API to check for tiles along the path
        Vector2 currentPos = start;
        Vector2 direction = (end - start).normalized;
        float distance = Vector2.Distance(start, end);
    
        for (float i = 0; i < distance; i += 0.1f)
        {
            currentPos = start + direction * i;
            Vector3Int cellPosition = platformTilemap.WorldToCell(currentPos);
    
            if (platformTilemap.HasTile(cellPosition))
            {
                return true;
            }
        }
    
        return false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
