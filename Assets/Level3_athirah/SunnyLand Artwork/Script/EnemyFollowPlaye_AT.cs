using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollowPlayer_AT : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player != false)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            
            if (distanceFromPlayer < lineOfSite)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                if (transform.position.x > player.position.x)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (transform.position.x < player.position.x)
                {   
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}