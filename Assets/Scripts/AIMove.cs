using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour {

    GameObject go;

    // Use this for initialization
    void Start () {
        if(GameObject.FindObjectOfType<charactMove>())
        go = GameObject.FindObjectOfType<charactMove>().gameObject;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        GetComponent<Rigidbody2D>().velocity *= 0.99f;

        if (go != null)
        {
            transform.position += (go.transform.position - transform.position).normalized * Time.deltaTime;

            Vector3 go_pos = new Vector3(go.transform.position.x, go.transform.position.y);
            go_pos.x = go_pos.x - transform.position.x;
            go_pos.y = go_pos.y - transform.position.y;
            float angle = Mathf.Atan2(go_pos.y, go_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
