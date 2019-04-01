using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    
    int bulletCount = 0;
    public GameObject obje;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
      
	}
        
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {

            Destroy(coll.gameObject);

            bulletCount++;

            if (bulletCount == 3)
            {

                    GameObject obj = Instantiate(obje, new Vector3( transform.position.x,transform.position.y,transform.position.z), transform.rotation);
                    Animator anim = obje.GetComponent<Animator>();
                    anim.Play("bomb");
                
                 Destroy(gameObject);
                Destroy(obj, 1.5f);

            }

    
        }

    }
    
}
