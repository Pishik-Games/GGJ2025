using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;
    public Transform bubble;
    public float maxBubbleScale = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; 
    }

    void Update()
    {
         BubbleLogic();
         HorizontalMovment();
    }

    private void BubbleLogic()
    {
        if(Input.GetKey("space"))
        {
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

    void HorizontalMovment()
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
