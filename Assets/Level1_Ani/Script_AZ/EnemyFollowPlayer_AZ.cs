using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer_AZ : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != false)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

            if (distanceFromPlayer < lineOfSite)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                animator.SetBool("isMoving", true);  // Set animator parameter to true

                if (transform.position.x > player.position.x)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (transform.position.x < player.position.x)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            else
            {
                animator.SetBool("isMoving", false);  // Set animator parameter to false
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}