using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class charactLife : NetworkBehaviour
{

    [SyncVar]
    public int life = 3;

    private Camera cam;

    [SyncVar]
    public string lastKiler;

    ScorePanel score;
    // Use this for initialization
    void Start () {

        cam = Camera.main.GetComponent<Camera>();
        score = GameObject.FindObjectOfType<ScorePanel>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((transform.position.x > cam.transform.position.x + cam.orthographicSize * cam.aspect) ||
            (transform.position.x < cam.transform.position.x - cam.orthographicSize * cam.aspect) ||
            (transform.position.y > cam.transform.position.y + cam.orthographicSize) ||
            (transform.position.y < cam.transform.position.y - cam.orthographicSize))
        {

            transform.position = Vector3.zero;

            life--;
            if(life <= 0)
            {
                GameObject.Destroy(this.gameObject);
                if (lastKiler != "")
                {
                    score.add(lastKiler);
                    lastKiler = "";
                }
                if(GetComponent<NetworkIdentity>())
                if (GetComponent<NetworkIdentity>().isLocalPlayer)
                {
                    GameObject.FindObjectOfType<MainMenuScript>().disconect();
                }
            }
        }
    }
}
