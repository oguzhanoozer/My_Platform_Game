using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPlayAnimation : MonoBehaviour {

    public int directionNumber;
    public GameObject frogleft,frogRight;


    private Animator animator;
    private SpriteRenderer render;
    private CircleCollider2D circleCollider2D;

   

    // Use this for initialization
    void Start () {
        animator = transform.GetComponentInChildren<Animator>();
        render = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
      //  frogleft = frogleft.GetComponent<Frog>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {


            animator.enabled = true;
            render.enabled = false;
            circleCollider2D.enabled = false;


            if (directionNumber == 0)
            {
                
                animator.Play("LeftBlock");
                frogRight.SetActive(true);
            }
            else
            {
                animator.Play("RightBlock");
                frogleft.SetActive(true);
            }
        

        }
    }

}
