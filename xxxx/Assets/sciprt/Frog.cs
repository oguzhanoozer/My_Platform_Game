using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {


    public int frogDirection;
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

        if (frogDirection == 0)
        {
           
            rigidbody2D.AddForce(Vector3.right * fireSpeed);
        }
        else if(frogDirection == 1)
        {
            rigidbody2D.AddForce(Vector3.left * fireSpeed);
        }



    }

}
