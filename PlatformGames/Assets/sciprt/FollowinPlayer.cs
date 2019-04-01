using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowinPlayer : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(player.position.y>0f)
           transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);

        if (player.position.y > 18)
            transform.position = new Vector3(transform.position.x,18f, transform.position.z);

    }
}
