using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AZ: MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    bool facingRight;

    // Start is called before the first frame update 
    void Start()
    {

    }
    // Update is called once per frame 
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && !collision.collider.CompareTag("Player") && collision.collider.CompareTag("Ground"))
        {
            facingRight = !facingRight;
        }

        if (facingRight)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}