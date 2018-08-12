using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartShow : MonoBehaviour {

    public charactLife life;
    public GameObject heartPrefab;

	// Use this for initialization
	void Start () {
        if(!life)
        {
            life = transform.parent.GetComponent<follow2D>().target.GetComponent<charactLife>();
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for(int i = 0; i < life.life; i++)
        {
            GameObject go = GameObject.Instantiate(heartPrefab, this.transform);
        }

    }
}
