using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEffect : MonoBehaviour
{

    public float Live = 1.0f;
    float InLive;

    public string shooter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InLive < Live)
        {
            InLive += Time.deltaTime;
        }
        else
            GameObject.Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Rigidbody2D rigid = col.collider.GetComponent<Rigidbody2D>();
        if(rigid) rigid.AddForce(transform.right*4.0f,ForceMode2D.Impulse);

        charactLife life = col.collider.GetComponent<charactLife>();
        if(life) life.lastKiler = shooter;

        
        GameObject.Destroy(this.gameObject);
    }
}
