using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_AZ : MonoBehaviour
{
    float moveInput;
    public Rigidbody2D rb;
    public float speed;
    public Transform pos;
    public float radius;
    public LayerMask groundLayers;
    public float jumpforce;
    public float heightCutter;
    bool grounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update 
    void Start()
    {

    }

    // FixedUpdate is called before Update, at the same rate based on Delta Time 
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0f)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < 0f)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame 
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircle(pos.position, radius, groundLayers);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * heightCutter);
            }
        }
    }
}