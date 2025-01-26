using System;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;
    public Transform bubble;
    public float maxBubbleScale = 5f;
    
    public float health = 100f; // 0..100
    public float healthDecreaseSpeed = 0.5f;
    public float jumpPower = 7f; 
    public float bubblePower = 0.35f; 
    [SerializeField]private bool canJump = true;
    public LayerMask groundLayer;
    public Transform groundDetector;
    [SerializeField] private Animator _animator;
    private bool _canMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        _canMove = false;
    }
    
    void FixedUpdate()
    {
        if (_canMove)
        {
            GroundDetector();
            BubbleLogic();
            HorizontalMovement();
            LoseDetector();   
        }
    }

    private void LoseDetector()
    {
        if (health <= 0)
        {
            // TODO GameManager.OnDead();
        }
    }

    private void BubbleLogic()
    {
        health -= healthDecreaseSpeed / 10;

        if (canJump)
        {
            if(Input.GetKeyDown("space"))
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        
        if(Input.GetKeyDown("space"))
            SoundPlayer.PlayBubble();

        
        if(Input.GetKeyUp("space"))
            ShrinkBubble();
        
        
        if(Input.GetKey("space") && !canJump)
        {
            bubble.gameObject.SetActive(true);
            health -= healthDecreaseSpeed;
            rb.AddForce(Vector2.up * bubblePower, ForceMode2D.Impulse);
            if (bubble.localScale.x < maxBubbleScale)
                bubble.localScale += Vector3.one * 0.1f;
        }
    }

    public void ShrinkBubble()
    {
        bubble.localScale = Vector3.one * 0.2f;
        bubble.gameObject.SetActive(false);
    }

    void HorizontalMovement()
    {


        var moveInput = Input.GetAxis("Horizontal");
        
        
        if (moveInput != 0)
        {
            _animator.SetBool("Walking", true);
        }
        else
        {
            _animator.SetBool("Walking", false);

        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    
        if(canJump)
            if (Math.Abs(moveInput) > 0.2)
                SoundPlayer.PlayWalking();
            else
                SoundPlayer.PauseWalking();
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        transform.localScale = moveInput switch {
            > 0 => new Vector3(1, 1, 1),
            < 0 => new Vector3(-1, 1, 1),
            _ => transform.localScale
        };
    }
    private void GroundDetector()
    {
        var oldCanJump = canJump;
        canJump = Physics2D.OverlapCircle(groundDetector.position, 0.68f, groundLayer);
        if (!oldCanJump && canJump) ShrinkBubble(); // on hit ground
    }

    public void CanMove(bool b)
    {
        _canMove = b;
    }
}
