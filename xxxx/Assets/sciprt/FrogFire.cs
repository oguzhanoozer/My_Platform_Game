using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogFire : MonoBehaviour {

    public GameObject target;
    
    public GameObject fireToPlayer;
    public Transform fireSpawn;

    private float counter = 0f, thresHold;
    private float fireSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        thresHold = Random.Range(0.75f, 2f);

        counter += Time.deltaTime;
        if (counter > thresHold)
        {
            FireCreat();
            counter = 0f;
        }

    }


    void FireCreat()
    {
        GameObject fireOfPlayer = Instantiate(fireToPlayer, fireSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigidbody2D = fireOfPlayer.GetComponent<Rigidbody2D>();

        fireSpeed = Random.Range(250f, 400f);

        Vector3 currentScale = transform.localScale;


        if (currentScale.x<0.0f)
        {
            rigidbody2D.AddForce(Vector3.right * fireSpeed);
        }
        else
        {
            rigidbody2D.AddForce(Vector3.left * fireSpeed);
        }

      //  if (target.transform.position.x > transform.position.x)
       // {

//            rigidbody2D.AddForce(Vector3.right * fireSpeed);
  //      }
        //else if (target.transform.position.x < transform.position.x)
    //    {
      //      rigidbody2D.AddForce(Vector3.left * fireSpeed);
        //}



    }


}
