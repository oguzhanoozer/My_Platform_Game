using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEnter : MonoBehaviour {
    
    public Sprite sprite;
    public GameObject house;

    private SpriteRenderer render;


    // Use this for initialization
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            render.sprite = sprite;
            house.SetActive(true);
            
        }
    }

}
