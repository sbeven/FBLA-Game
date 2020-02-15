using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{
    [SerializeField] public SimpleHealthBar healthBar;
    //start() variables
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private Animator anim;
    private Collider2D coll;

    //fsm
    private enum State { idle, running, jumping, falling, hurt }
    private State state = State.idle;

    //inspector variables, audio
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private AudioSource Coin;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource recruit;
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource checksound;
    [SerializeField] private int health = 3;
    // [SerializeField] private string sceneToLoad;
    int maxHealth = 0;
    int recruits = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        //teleport to checkpoint in fourth level
        if ((PermanentUI.perm.checkpoint != 0) && ((SceneManager.GetActiveScene().name == "Fourth Level") || (SceneManager.GetActiveScene().name == "Second Level final")))
        {
            transform.position = PermanentUI.perm.cppos;
        }
        maxHealth = health;
        healthBar.UpdateBar(health, maxHealth);
    }

    private void Update()
    {
        PermanentUI.perm.LastScene = SceneManager.GetActiveScene().buildIndex;
        if (state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        PermanentUI.perm.pointAmount.text = PermanentUI.perm.points.ToString();
        anim.SetInteger("state", (int)state); //sets animation based on enumerator state
        PermanentUI.perm.livesAmount.text = "Lives: " + PermanentUI.perm.lives.ToString();
        if (PermanentUI.perm.lives <= 0)
        {
            SceneManager.LoadScene("Ending");
            PermanentUI.perm.lives = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Coin.Play();
            Destroy(collision.gameObject);
            PermanentUI.perm.coins += 1;
            PermanentUI.perm.coinText.text = PermanentUI.perm.coins.ToString();
            PermanentUI.perm.levelpoints = PermanentUI.perm.levelpoints + 10;
//            PermanentUI.perm.points += 10;
            if (PermanentUI.perm.coins == 75)
            {
                PermanentUI.perm.nextlevel();
            }
        }
        if (collision.tag == "Adventurer")
        {
            recruit.Play();
            Destroy(collision.gameObject);
            recruits = recruits + 1;
            if(recruits >= 15)
            {
                PermanentUI.perm.nextlevel();
            }
        }
        if (collision.tag == "Door")
        {
            PermanentUI.perm.nextlevel();
        }
        if (collision.tag == "Checkpoint")
        {
            Checkpoint Checkpoint = collision.GetComponent<Checkpoint>();
            if (PermanentUI.perm.checkpoint - Checkpoint.checkpointnumber < 1)
            {
            PermanentUI.perm.checkpoint = 1 + Checkpoint.checkpointnumber;
            checksound.Play();
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            Enemy Enemy = other.gameObject.GetComponent<Enemy>();
            RaycastHit2D hit = Physics2D.BoxCast(rb.position, box.bounds.size - Vector3.up, 0f, Vector2.down, 1f, enemy);
            if ((hit.collider != null) && (state == State.falling))
            {
                Enemy.JumpedOn();
                Jump();
            }
            else
            {
                state = State.hurt;
                
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //enemy is to right therefore i should be damaged and move left
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    //enemy is to my left therefore i should be damaged and move right
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
                TakeDamage(1);
                if (health == 0)
                {
                    PermanentUI.perm.lives = PermanentUI.perm.lives - 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    PermanentUI.perm.points = PermanentUI.perm.points - 20;
                    PermanentUI.perm.Reset();
                    health = 3;
                    healthBar.UpdateBar(health, maxHealth);
//                    PermanentUI.perm.die.Play();
                }
            }
        }
    }

    private void Movement()
    {
        //left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        // added (not in tutorial)
        else
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y);
        }
        //jumping
        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.BoxCast(rb.position, box.bounds.size - Vector3.up, 0f,  Vector2.down, 1f, ground);
            if (hit.collider != null)
            {
                Jump();
                jump.Play();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void AnimationState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {

            RaycastHit2D hit = Physics2D.BoxCast(rb.position, box.bounds.size, 0f, Vector2.down, 1f, ground);
            if (Mathf.Abs(rb.velocity.y) <= .1f)
            {
                state = State.idle;
            }

            //breaks animation when hitting ceiling
            //if (hit.collider != null)
            //{
            //    state = State.idle;
            //}

        } else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //moving

            if (rb.velocity.y < -.1f)
            {

                state = State.falling;
            }
            else
            {
                state = State.running;
            }
        }
        else
        {
            if (rb.velocity.y < -.1f)
            {
                state = State.falling;
            }
            else
            {
                state = State.idle;
            }
        }
    }

    private void Footstep()
    {
        footstep.Play();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.UpdateBar(health, maxHealth);
    }
}
