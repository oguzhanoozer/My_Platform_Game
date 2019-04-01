using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{

    public GameObject fireToPlayer;
    public Transform fireSpawn;

    private float counter = 0f, thresHold = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter>thresHold)
        {
            FireCreat();
            counter = 0f;
        }
       
    }

  
    void FireCreat()
    {
        GameObject fireOfPlayer = Instantiate(fireToPlayer, fireSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigidbody2D = fireOfPlayer.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector3.down * 50f);

    }


}
