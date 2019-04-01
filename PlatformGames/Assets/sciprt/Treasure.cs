using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    public Sprite sprite;
    public Camera mainCamera;
    public GameObject map;

    Animator animator;
    Vector3 firstPosOfCamera;

    SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        firstPosOfCamera = mainCamera.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            animator.enabled = true;
            spriteRenderer.sprite = sprite;
            StartCoroutine(SecondLevel());
        }
        
    }

    IEnumerator SecondLevel()
    {
        yield return new WaitForSeconds(2f);
        map.gameObject.SetActive(true);
    }


}
