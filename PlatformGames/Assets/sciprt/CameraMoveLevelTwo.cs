using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveLevelTwo : MonoBehaviour {

    public GameObject player;
    private Vector3 previousPosition;


    private void Awake()
    {
       //  player = SelectCharacter.instance.activeGameObje;
     }

    // Use this for initialization
    void Start () {
        previousPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (player.transform.position.x < -50f)
        {
            transform.position = previousPosition;                
        }else if(player.transform.position.x >= -50f && player.transform.position.x<108f)
        {
            transform.position= new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }else if (player.transform.position.x >= 108f)
        {
            
            transform.position = new Vector3(108f, transform.position.y, transform.position.z);
        }

	}
}
