using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawnAI : NetworkBehaviour
{

    public float spawnRate = 1.0f;
    public float spawnin = 0.0f;

    public GameObject prefab;
    private Camera cam;

    void Start ()
    {
        cam = Camera.main.GetComponent<Camera>();
    }
	
	void Update () {

        if ((transform.position.x < cam.transform.position.x + cam.orthographicSize * cam.aspect) &&
    (transform.position.x > cam.transform.position.x - cam.orthographicSize * cam.aspect) &&
    (transform.position.y < cam.transform.position.y + cam.orthographicSize) &&
    (transform.position.y > cam.transform.position.y - cam.orthographicSize))
        {
            if (spawnRate > spawnin)
            {
                Debug.Log("test");
                spawnin += Time.deltaTime * Random.Range(0.1f, 1.0f);
            }
            else
            {
                CmdSpawn();
                spawnin = 0;
            }
        }
    }

    [Command]
    void CmdSpawn()
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = transform.position;
    }
}
