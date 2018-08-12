using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeReduce : MonoBehaviour {

    Camera cam;
	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        cam.orthographicSize -= cam.orthographicSize * (Time.deltaTime*Time.deltaTime);

    }
}
