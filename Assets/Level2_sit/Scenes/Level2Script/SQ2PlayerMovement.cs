using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SQ2PlayerMovement : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;
        private bool facingRight = false;
        private bool isGrounded;
        bool grounded;

        public Transform groundCheck;
        private Rigidbody2D rb;
        private Animator animator;
        public float radius;
        public LayerMask groundLayers;
        private SQ2HerbCollect herbCollect;

        private float zTimeRemaining = 0;
        private float xTimeRemaining = 0;
        private float invulnerabilityTimeRemaining = 0;
        private int life = 3;
        private float hurtForce = 5f;

        [SerializeField] private Text lifeText;
        [SerializeField] private AudioSource waterSFX;
        [SerializeField] private AudioSource jumpSoundEffect;
        [SerializeField] private AudioSource hurtSoundEffect;
        [SerializeField] private AudioSource speedBoostEffect;
        [SerializeField] private AudioSource jumpBoostEffect;
        [SerializeField] private AudioSource defenseBoostEffect;
        [SerializeField] private ParticleSystem speedParticle;
        [SerializeField] private ParticleSystem jumpParticle;
        [SerializeField] private ParticleSystem defenseParticle;


        private int herbPower = 0;

        // Start is called before the first frame 
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            herbCollect = FindObjectOfType<SQ2HerbCollect>();
            speedParticle.Stop();
            jumpParticle.Stop();
            defenseParticle.Stop();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        // Update is called once per frame 
        void Update()
        {
            herbPower = herbCollect.herbPoint;
            grounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayers);
            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation 
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); //Turn on idle animation
            }
            if (Input.GetKeyDown(KeyCode.Space) && grounded && isGrounded)
            {
                jumpSoundEffect.Play();
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            if (!isGrounded) animator.SetInteger("playerState", 2); //Turn on jump 
            if (facingRight == false && moveInput < 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput > 0)
            {
                Flip();
            }
            if (Input.GetKeyDown(KeyCode.Z) && herbCollect.herbPoint > 0)
            {
                speedBoostEffect.Play();
                StartCoroutine(DoubleMovingSpeed());
                herbCollect.AddHerbPower(-1);
            }
            if (Input.GetKeyDown(KeyCode.X) && herbCollect.herbPoint > 0)
            {
                jumpBoostEffect.Play();
                StartCoroutine(DoubleJumpForce());
                herbCollect.AddHerbPower(-1);
            }
            if (Input.GetKeyDown(KeyCode.C) && herbCollect.herbPoint > 0)
            {
                defenseBoostEffect.Play();
                StartCoroutine(DefenseBoost());
                herbCollect.AddHerbPower(-1);
            }
        }

        private IEnumerator DoubleMovingSpeed()
        {
            speedParticle.Play();
            float originalMovingSpeed = movingSpeed;
            movingSpeed = 10;
            zTimeRemaining = 8f;
            while (zTimeRemaining > 0)
            {
                yield return new WaitForSeconds(0.1f);
                zTimeRemaining -= 0.1f;
            }
            movingSpeed = originalMovingSpeed;
            speedParticle.Stop();
        }

        private IEnumerator DoubleJumpForce()
        {
            jumpParticle.Play();
            float originalJumpForce = jumpForce;
            jumpForce = 15;
            xTimeRemaining = 12f;
            while (xTimeRemaining > 0)
            {
                yield return new WaitForSeconds(0.1f);
                xTimeRemaining -= 0.1f;
            }
            jumpForce = originalJumpForce;
            jumpParticle.Stop();
        }

        private IEnumerator DefenseBoost()
        {
            defenseParticle.Play();
            invulnerabilityTimeRemaining = 5f;
            while (invulnerabilityTimeRemaining > 0)
            {
                yield return new WaitForSeconds(0.1f);
                invulnerabilityTimeRemaining -= 0.1f;
                life = 3;
                lifeText.text = "Life: " + life;
            }
            defenseParticle.Stop();
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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                hurtSoundEffect.Play();
                life--;
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
                    gameObject.SetActive(false);
                    Invoke("LoadLevelGame", 2.0f);
                }
            }
            if (other.gameObject.tag == "Fall")
            {
                waterSFX.Play();
                life = 0;
                UpdateLifeText();
                gameObject.SetActive(false);
                Invoke("LoadLevelGame", 2.0f);
            }
        }
        void LoadLevelGame()
        {
            SceneManager.LoadScene("Level2");
        }

        private void UpdateLifeText()
        {
            if (lifeText != null)
            {
                lifeText.text = "Life: " + life;
            }
        }
    }
}