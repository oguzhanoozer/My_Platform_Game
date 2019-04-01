using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    
    public GameObject fireToPlayer;
    public Transform fireSpawn;

    private float counter = 0f, thresHold;
    private float fireSpeed;

    public SelectCharacter select;

    // Use this for initialization
    void Start()
    {
        select.GetComponent<SelectCharacter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

            transform.position = new Vector3(select.activeGameObje.transform.position.x + 3, transform.position.y, transform.position.z);

            thresHold = Random.Range(0.75f, 1.5f);

            counter += Time.deltaTime;
            if (counter > thresHold)
            {
                FireCreat();
                counter = 0f;
            }

        }
        catch
        {

        }

    }


    void FireCreat()
    {
        GameObject fireOfPlayer = Instantiate(fireToPlayer, fireSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigidbody2D = fireOfPlayer.GetComponent<Rigidbody2D>();

        fireSpeed = Random.Range(300f, 400f);

        if (transform.position.x< select.activeGameObje.transform.position.x)
        {

            rigidbody2D.AddForce(Vector3.right * fireSpeed);
        }
        else if (transform.position.x > select.activeGameObje.transform.position.x)
        {
            rigidbody2D.AddForce(Vector3.left * fireSpeed);
        }



    }


}
