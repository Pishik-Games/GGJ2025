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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; 
    }

    void Update()
    {
         BubbleLogic();
         HorizontalMovement();
         LoseDetector();
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
        
        if(Input.GetKeyDown("space"))
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        
        if(Input.GetKey("space"))
        {
            health -= healthDecreaseSpeed;
            rb.AddForce(Vector2.up * bubblePower, ForceMode2D.Impulse);
            if (bubble.localScale.x < maxBubbleScale)
            {
                bubble.localScale += Vector3.one * 0.1f;
            }
        }
        else
        {
            bubble.localScale = Vector3.one;
        }
    }

    void HorizontalMovement()
    {
        var moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        transform.localScale = moveInput switch {
            > 0 => new Vector3(1, 1, 1),
            < 0 => new Vector3(-1, 1, 1),
            _ => transform.localScale
        };
    }

}
