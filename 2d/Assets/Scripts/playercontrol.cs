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

    //inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private AudioSource Coin;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource recruit;
    [SerializeField] private AudioSource jump;
    [SerializeField] private int health = 3;
//    [SerializeField] private string sceneToLoad;
    int maxHealth = 0;
    int recruits = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        maxHealth = health;
        healthBar.UpdateBar(health, maxHealth);
        
    }

    private void Update()
    {
        if (state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        PermanentUI.perm.pointAmount.text = PermanentUI.perm.points.ToString();
        anim.SetInteger("state", (int)state); //sets animation based on enumerator state
        if (SceneManager.GetActiveScene().name == "first level")
        {
            if (PermanentUI.perm.coins == 2)
            {
                PermanentUI.perm.LastScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Transition");
            }
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
            PermanentUI.perm.points = PermanentUI.perm.points + 10;
            PermanentUI.perm.levelpoints = PermanentUI.perm.levelpoints + 10;
        }
        if (collision.tag == "Adventurer")
        {
            recruit.Play();
            Destroy(collision.gameObject);
            recruits = recruits + 1;
            if (recruits == 3)
            {
                PermanentUI.perm.LastScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Transition");
            }
        }
        if (collision.tag == "Door")
        {
            PermanentUI.perm.points = PermanentUI.perm.points + 100;
            PermanentUI.perm.levelpoints = 0;
            PermanentUI.perm.Reset();
            PermanentUI.perm.LastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Transition");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            Enemy Enemy = other.gameObject.GetComponent<Enemy>();
            if ((state == State.falling))
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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    PermanentUI.perm.Reset();
                    PermanentUI.perm.points = PermanentUI.perm.points - 20;
                    health = 3;
                    healthBar.UpdateBar(health, maxHealth);
                }
            }
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.K))
        {
            SceneManager.LoadScene("Input");
        }
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
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        }
        //jumping
        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.BoxCast(rb.position, box.bounds.size, 0f,  Vector2.down, 0.5f, ground);
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

            RaycastHit2D hit = Physics2D.BoxCast(rb.position, box.bounds.size, 0f, Vector2.down, 0.5f, ground);
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
