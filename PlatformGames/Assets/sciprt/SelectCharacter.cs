using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour {
    

    public GameObject[] character;
    public GameObject startPanel;
    public GameObject activeGameObje;
    
    private Vector3 previousPosition;
    
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    // Use this for initialization
    void Start () {
        previousPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        try
        {

            if (activeGameObje.transform.position.x < -50f)
            {
                transform.position = previousPosition;
            }
            else if (activeGameObje.transform.position.x >= -50f && activeGameObje.transform.position.x < 108f)
            {
                transform.position = new Vector3(activeGameObje.transform.position.x, transform.position.y, transform.position.z);
            }
            else if (activeGameObje.transform.position.x >= 108f)
            {

                transform.position = new Vector3(108f, transform.position.y, transform.position.z);
            }
        }
        catch
        {

        }


    }

    public void SelectKnight()
    {
        GameObject Knight = Instantiate(character[0], new Vector2(-58f, 38f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        activeGameObje = Knight;
        Activated(activeGameObje);

    }
    public void SelectZombi()
    {
        GameObject Zombi= Instantiate(character[1], new Vector2(-58f, 38f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        activeGameObje = Zombi;
        Activated(activeGameObje);

    }
    public void SelectMane_Black()
    {
        GameObject Mane_Black = Instantiate(character[2], new Vector2(-58f, 38f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        activeGameObje = Mane_Black;
        Activated(activeGameObje);

    }
    public void SelectArcher()
    {
        GameObject Archer = Instantiate(character[3], new Vector2(-58f, 38f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        activeGameObje = Archer;
        Activated(activeGameObje);

    }

    void Activated(GameObject obj)
    {
        obj.GetComponent<AnimationPlay>().health=100;
        Time.timeScale = 1f;
        obj.SetActive(true);
        startPanel.SetActive(false);
    }

}
