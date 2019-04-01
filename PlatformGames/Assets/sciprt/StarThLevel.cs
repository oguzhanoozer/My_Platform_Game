using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarThLevel : MonoBehaviour {

    public Camera mainCamera;
    public AnimationPlay player;

    Vector3 firstPosOfCamera;

	// Use this for initialization
	void Start () {
        firstPosOfCamera = mainCamera.transform.position;
        player = player.GetComponent<AnimationPlay>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            StartCoroutine(SecondLevel());
        }

    }

    IEnumerator SecondLevel()
    {
        yield return new WaitForSeconds(2f);
        mainCamera.transform.position = new Vector3(firstPosOfCamera.x, 17, firstPosOfCamera.z);
        player.gameObject.transform.position = new Vector3(-0.16f, 12.81f, -20.8f);
    }

}
