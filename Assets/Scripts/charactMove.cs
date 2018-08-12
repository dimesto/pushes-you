using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactMove : MonoBehaviour {

    float speed = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity *= 0.975f;


        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed,
                                        Input.GetAxis("Vertical") * Time.deltaTime * speed,
                                        0);

        Vector3 mouse_pos = Input.mousePosition;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
