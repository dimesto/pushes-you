using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow2D : MonoBehaviour {

    public Vector3 offeset;
    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
            transform.position = target.position + offeset;
        else
            GameObject.Destroy(this.gameObject);

    }
}
