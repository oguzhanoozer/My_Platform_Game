using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecLevBrownChest : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            animator.enabled = true;
        }
    }

}
