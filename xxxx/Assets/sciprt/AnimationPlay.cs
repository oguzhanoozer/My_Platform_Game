using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPlay : MonoBehaviour
{

    public float jumpForce = 700f;
    public float movementSpeed = 5f;
    public GameObject fireGameObject;
    public Transform fireSpawn;
    public Slider healthSlider;


    Animator animator;
    Rigidbody2D rigidbody2D;
    bool faceRight = true;
    int jumperCounter;
    bool isJumperCheck = true;
    bool movementChecer;
    int attackCounter;
    bool isCollider;
    
    public int health;

    bool isGrounded = false;
    public Transform groundedChecker;
    public LayerMask groundLayer;
    public float radius = 0.2f;

    private void Awake()
    {
        healthSlider = (Slider)FindObjectOfType(typeof(Slider));
    }

    // Use this for initialization
    void Start()
    {
        health = 100;
        healthSlider.value = health;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;


        isGrounded = Physics2D.OverlapCircle(groundedChecker.position, radius, groundLayer);


        if (isGrounded && !movementChecer)
        {
            jumperCounter = 0;
            animator.SetBool("isIdle", true);
        }
        else if (isGrounded && movementChecer)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.SetTrigger("isDash");
            }
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isAttack");

           if(isCollider)
           {
                attackCounter++;
           }
          
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            animator.SetTrigger("isShooting");
            Fire();
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && jumperCounter <1)
        {
            
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            animator.SetTrigger("isJump");
            jumperCounter++;
           
        }

    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime);

        if (Mathf.Abs(movement) > 0)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
            movementChecer = true;
        }
        else if (Mathf.Abs(movement) == 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
            movementChecer = false;
        }

        if (movement > 0 && !faceRight)
        {
            Flip();
        }
        else if (movement < 0 && faceRight)
        {
            Flip();
        }

    }

    
    void Flip()
    {
        faceRight = !faceRight;

        Vector3 currentScale = transform.localScale;

        currentScale.x *= -1;

        transform.localScale = currentScale;

    }

    void Fire()
    {
       
        GameObject bulletInstance = Instantiate(fireGameObject, fireSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigidbody = bulletInstance.GetComponent<Rigidbody2D>();
     
        if(faceRight)
            rigidbody.AddForce(Vector3.right * 400F);
        else
            rigidbody.AddForce(Vector3.left * 400F);

        
        Destroy(bulletInstance, 1.5f);

    }

    void Died()
    {
        animator.SetTrigger("isDie");
        Destroy(gameObject, 2f);
    }


    float timer;

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {   
            isCollider = true;
            
            print(attackCounter);

            if (attackCounter == 3)
            {
                Destroy(coll.gameObject);
                attackCounter = 0;
                isCollider = false;
            }

        }


        if (coll.gameObject.tag == "coin" || coll.gameObject.tag=="star" || coll.gameObject.tag=="gem" || coll.gameObject.tag=="chery")
        {
            Destroy(coll.gameObject);
        }


        if (coll.gameObject.tag == "secTreasureBlock")
        {
            print("degdi");
           
            timer += Time.deltaTime;
            if (timer >= 1.0f){
                Destroy(coll.gameObject);

                print(timer);
                timer = 0.0f;
            }
             
        }

        

        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "eagle")
        {
            Died();
        }
        if (coll.gameObject.tag == "fire")
        {
            health =health- 10;
             Destroy(coll.gameObject);

            if (health == 0)
            {
               
                Died();
            }
        }

        if (coll.gameObject.tag == "coin" || coll.gameObject.tag == "star" || coll.gameObject.tag == "gem" || coll.gameObject.tag == "chery")
        {
            Destroy(coll.gameObject);
        }

    }
    
}
