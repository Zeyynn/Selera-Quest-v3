using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jump;
        private float moveInput;
        private bool facingRight = false;
        private bool isGrounded;
        public Transform groundCheck;
        private Rigidbody2D rb;
        private Animator animator;
        public float radius;
        public LayerMask groundLayers;
        public bool isJumping;
        bool grounded;

        private int life = 3;
        private float hurtForce = 8f;
        [SerializeField]
        private Text lifeText;
        //public ParticleSystem deathPlayer;

        [SerializeField] private GameObject gameOver;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            CheckGround();
        }
        // Update is called once per frame
        void Update()
        {

            grounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayers);
            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position +
               direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); //Turn on idle animation
            }
            if (Input.GetButtonDown("Jump") && isJumping == false)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
            }
            if (!isGrounded) animator.SetInteger("playerState", 2); //Turn on jump animation
            if (facingRight == false && moveInput < 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput > 0)
            {
                Flip();
            }
        }
        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, radius, groundLayers);
            isGrounded = colliders.Length > 0; // Change to check if there's at least one collider
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                life -= 1;
                lifeText.text = "Life: " + life;
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
                if (life == 0)
                {
                    gameOver.SetActive(true);
                    //Instantiate(deathPlayer, transform.position, Quaternion.identity);
                    gameObject.SetActive(false);
                    Invoke("LoadLevelGame", 2.0f);
                }
            }
        }
    }
    

}
