using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnPointRegister : MonoBehaviour {

    NetworkManager manager;
    void Awake()
    {
        manager = GameObject.FindObjectOfType<NetworkManager>();
        if(manager)
        manager.spawnPrefabs.Add(this.gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
