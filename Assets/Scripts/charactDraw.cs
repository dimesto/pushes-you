using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactDraw : MonoBehaviour {

    public List<GameObject> prefabs = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
        foreach(GameObject prefab in prefabs)
        {
            GameObject go = GameObject.Instantiate(prefab);
            if(go.GetComponent<follow2D>())
            go.GetComponent<follow2D>().target = this.transform;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
