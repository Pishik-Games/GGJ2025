using UnityEngine;

public class Player : MonoBehaviour {
    
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;
    public Transform bubble;
    public float maxBubbleScale = 5f;
    
    public float health = 100f; // 0..100
    public float healthDecreaseSpeed = 0.5f; // 0..100

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
        if(Input.GetKey("space"))
        {
            health -= healthDecreaseSpeed;
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
