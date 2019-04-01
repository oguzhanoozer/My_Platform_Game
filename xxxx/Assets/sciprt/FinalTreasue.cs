using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalTreasue : MonoBehaviour
{

    public Sprite sprite;
    public GameObject panelFinish;

    Animator animator;
    SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            animator.enabled = true;
            spriteRenderer.sprite = sprite;
            StartCoroutine(GameFinish());
        }

    }

    IEnumerator GameFinish()
    {
        yield return new WaitForSeconds(2f);
        panelFinish.SetActive(true);
        yield return new WaitForSeconds(2f);
        panelFinish.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
