﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockToTreasure : MonoBehaviour {

    int hitCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            print("block");
            hitCounter++;

        }


        if (hitCounter == 3)
        {
            Destroy(gameObject);
            hitCounter = 0;
        }

    }


}
