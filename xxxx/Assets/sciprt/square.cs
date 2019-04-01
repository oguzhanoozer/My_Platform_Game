using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour {

    Vector3 newPos;
    Vector3 currentPosition;

	// Use this for initialization
	void Start () {
        currentPosition = transform.position;
        newPos = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);

    }

    // Update is called once per frame
    void Update () {
         
    }

    private void FixedUpdate()
    {
        // transform.position = Vector3.Lerp(transform.position, newPos,Time.deltaTime/3);
        // transform.position = Vector3.Lerp(transform.position,  currentPosition, Time.deltaTime / 3);

        StartCoroutine(Example());
    }



    IEnumerator Example()
    {
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime / 3);
        yield return new WaitForSeconds(3);
        transform.position = Vector3.Lerp(newPos, currentPosition, Time.deltaTime / 3);
    }

}
