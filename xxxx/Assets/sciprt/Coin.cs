using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject chainObje;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
            chainObje.GetComponent<Rigidbody2D>().bodyType =RigidbodyType2D.Dynamic;
            chainObje.GetComponent<HingeJoint2D>().enabled = true;
        }
    }

}
