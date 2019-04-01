using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEmpty : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="Player" || coll.gameObject.tag=="bullet")
        {
            transform.parent.GetComponent<Animator>().enabled = false;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }

    }

}
