using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour {

    public GameObject prefab;

    public float fireRate = 1.0f;
    float firein = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (fireRate > firein)
        {
            firein += Time.deltaTime;
        }
        else
        {
            GameObject go = GameObject.Instantiate(prefab);
            go.transform.position = transform.position + transform.right;
            go.transform.rotation = this.transform.rotation;
            firein = 0;
        }

    }
}
