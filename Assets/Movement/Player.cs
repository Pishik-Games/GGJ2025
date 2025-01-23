using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; 
    }

    void Update()
    {
        // Horizontal movement
        var moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        transform.localScale = moveInput switch {
            // Flip the character sprite based on movement direction
            > 0 => new Vector3(1, 1, 1),
            < 0 => new Vector3(-1, 1, 1),
            _ => transform.localScale
        };
    }

}
