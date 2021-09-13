using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;

public class Runner : MonoBehaviour
{
    public float runspeed;
    public static GameObject Player2;
    public GameObject Barbarian;
    public GameObject Knight;
    public GameObject runner;

    //camera for each player
    public Camera runnerCamera;


    public Animator animator;
    float horizontalMovement;
    bool jump = false;
    private Rigidbody2D rb;
    private bool facingRight;
    private bool jumping = false;
    private bool isGrounded = false;
    private Vector3 localScale;

    public float attackRange = 0.5f;
    //enemy layers for attack
    public LayerMask enemyLayers;
    public LayerMask knightLayers;
    public LayerMask barbarianLayers;

    public Transform attackPoint;

    public int attackDamage = 20;
    public int MaxHealth = 100;
    




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        localScale = transform.localScale;
        runspeed = 8f;
        Score.player1currentHealth = MaxHealth;
        Score.player2currentHealth = MaxHealth;
        //enemy layer is barbarian
        if (levelSelector.levelToStart == "Basic")
        {
            if (PlayerSelector.player1 == Barbarian || PlayerSelector.player2 == Barbarian)
            {
                enemyLayers = barbarianLayers;
            }
            //enemy layers is runner
            if (PlayerSelector.player1 == Knight || PlayerSelector.player2 == Knight)
            {
                enemyLayers = knightLayers;
            }
            //sets player1 camera to enabled 
            if (PlayerSelector.player1 == Barbarian || PlayerSelector.player1 == Knight)
            {
                runnerCamera.enabled = false;
            }
            else if (PlayerSelector.player1 == runner)
            {
                runnerCamera.enabled = true;
            }
        }
        else if (levelSelector.levelToStart == "Platformer" || levelSelector.levelToStart == "Jungle") 
        {
            if (PlayerSelector.player1 == Barbarian || PlayerSelector.player2 == Barbarian)
            {
                enemyLayers = barbarianLayers;
                runnerCamera.enabled = false;
            }
            //enemy layers is runner
            if (PlayerSelector.player1 == Knight || PlayerSelector.player2 == Knight)
            {
                enemyLayers = knightLayers;
                runnerCamera.enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (levelSelector.levelToStart == "Platformer" || levelSelector.levelToStart == "Jungle")
        {
            //player2 is selected 
            if (PlayerSelector.player1 == Barbarian || PlayerSelector.player1 == Knight)
            {
                horizontalMovement = CrossPlatformInputManager.GetAxis("P2Horizontal") * runspeed;
                if (CrossPlatformInputManager.GetButtonDown("P2Jump") && rb.velocity.y == 0)
                {
                    rb.AddForce(Vector2.up * 850f);
                }

                if (Mathf.Abs(horizontalMovement) > 0 && rb.velocity.y == 0)
                {
                    animator.SetBool("isRunning", true);

                }
                else
                {
                    animator.SetBool("isRunning", false);
                }

                if (rb.velocity.y == 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", false);
                }

                if (rb.velocity.y > 0)
                {
                    animator.SetBool("isJumping", true);

                }

                if (rb.velocity.y < 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", true);
                }
                if (CrossPlatformInputManager.GetButtonDown("Fire2"))
                {
                    animator.SetTrigger("meleeAttack");
                    Attack();
                }
            }
            //player1 is selected 
            if (PlayerSelector.player2 == Barbarian || PlayerSelector.player2 == Knight)
            {
                horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal") * runspeed;
                if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
                {
                    rb.AddForce(Vector2.up * 850f);
                }

                if (Mathf.Abs(horizontalMovement) > 0 && rb.velocity.y == 0)
                {
                    animator.SetBool("isRunning", true);

                }
                else
                {
                    animator.SetBool("isRunning", false);
                }

                if (rb.velocity.y == 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", false);
                }

                if (rb.velocity.y > 0)
                {
                    animator.SetBool("isJumping", true);

                }

                if (rb.velocity.y < 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", true);
                }
                if (CrossPlatformInputManager.GetButtonDown("Fire1"))
                {
                    animator.SetTrigger("meleeAttack");
                    Attack();
                }
            }
        }
        if (levelSelector.levelToStart == "Basic")
        {
            //player2 is selected 
            if (PlayerSelector.player1 == Barbarian || PlayerSelector.player1 == Knight)
            {
                horizontalMovement = CrossPlatformInputManager.GetAxis("P2Horizontal") * runspeed;
                if (CrossPlatformInputManager.GetButtonDown("P2Jump") && rb.velocity.y == 0)
                {
                    rb.AddForce(Vector2.up * 850f);
                }

                if (Mathf.Abs(horizontalMovement) > 0 && rb.velocity.y == 0)
                {
                    animator.SetBool("isRunning", true);

                }
                else
                {
                    animator.SetBool("isRunning", false);
                }

                if (rb.velocity.y == 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", false);
                }

                if (rb.velocity.y > 0)
                {
                    animator.SetBool("isJumping", true);

                }

                if (rb.velocity.y < 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", true);
                }
                if (CrossPlatformInputManager.GetButtonDown("Fire2"))
                {
                    animator.SetTrigger("meleeAttack");
                    Attack();
                }
            }
            //player1 is selected 
            if (PlayerSelector.player2 == Barbarian || PlayerSelector.player2 == Knight)
            {
                horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal") * runspeed;
                if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
                {
                    rb.AddForce(Vector2.up * 850f);
                }

                if (Mathf.Abs(horizontalMovement) > 0 && rb.velocity.y == 0)
                {
                    animator.SetBool("isRunning", true);

                }
                else
                {
                    animator.SetBool("isRunning", false);
                }

                if (rb.velocity.y == 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", false);
                }

                if (rb.velocity.y > 0)
                {
                    animator.SetBool("isJumping", true);

                }

                if (rb.velocity.y < 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", true);
                }
                if (CrossPlatformInputManager.GetButtonDown("Fire1"))
                {
                    animator.SetTrigger("meleeAttack");
                    Attack();
                }
            }
        }





    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }
    private void LateUpdate()
    {
        if (horizontalMovement > 0)
            facingRight = true;
        else if (horizontalMovement < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }
    public void TakeDamage(int damage)
    {
        if (PlayerSelector.player2 == Knight || PlayerSelector.player2 == Barbarian)
        {
            Score.player1currentHealth -= damage;
            if (Score.player1currentHealth <= -20)
            {
                Score.player2Score++;
                Score.player2currentHealth = 100;
                Score.player1currentHealth = 100;
                //transforms enemy position 
                transform.position = new Vector3(-5.05f, -3.57f, 0);

            }
        }
        if (PlayerSelector.player1 == Knight || PlayerSelector.player1 == Barbarian)
        {
            Score.player2currentHealth -= damage;
            if (Score.player2currentHealth <= -20)
            {
                Score.player1Score++;
                Score.player2currentHealth = 100;
                Score.player1currentHealth = 100;
                //PlayerSelector.player1.transform.position = new Vector3(-5.05f, -3.57f, 0);
                //PlayerSelector.player2.transform.position = new Vector3(5.89f, -3.47f, 0);
                transform.position = new Vector3(5.89f, -3.47f, 0);
            }
        }

    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (PlayerSelector.player1 == Barbarian || PlayerSelector.player2 == Barbarian)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            if(PlayerSelector.player1 == Knight || PlayerSelector.player2 == Knight)
            {
                enemy.GetComponent<MainCharacter>().TakeDamage(attackDamage);
            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
