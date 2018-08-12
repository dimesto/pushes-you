using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class charactShoot : NetworkBehaviour
{

    public GameObject prefab;

    public float fireRate = 1.0f;
    float firein = 0.0f;

    public MainMenuScript menu;
    // Use this for initialization
    void Start()
    {

        menu = GameObject.FindObjectOfType<MainMenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NetworkIdentity>().isLocalPlayer)
            if (fireRate > firein)
            {
                firein += Time.deltaTime;
            }
            else if (Input.GetAxis("Fire1") > 0)
            {
                Cmdshoot(menu.playerName);
                firein = 0;
            }
    }

    [Command]
    void Cmdshoot(string shooter)
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = transform.position + transform.right;
        go.transform.rotation = this.transform.rotation;

        go.GetComponent<bulletEffect>().shooter = shooter;
        NetworkServer.Spawn(go);
    }
}
