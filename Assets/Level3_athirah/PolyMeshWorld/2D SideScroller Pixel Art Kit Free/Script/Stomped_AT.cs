using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped_AT : MonoBehaviour
{
    public float bounce; 
    public float force;
    bool stomped = false;
    public ParticleSystem deathEnemy; 
    
    // Start is called before the first frame update
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            Rigidbody2D playerRb = trigger.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * force);
            stomped = true;
            BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
            playerRb.velocity = new Vector2(playerRb.velocity.x, bounce); 
            Instantiate(deathEnemy, transform.position, Quaternion.identity); 
            Destroy(transform.parent.gameObject); 
        }
    }
    private void OnBecameInvisible()
    {
        if (stomped == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}