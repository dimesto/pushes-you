using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NameShow : NetworkBehaviour
{

    [SyncVar]
    public string name;
    Text input;


    public MainMenuScript menu;
    // Use this for initialization
    void Start()
    {
        menu = GameObject.FindObjectOfType<MainMenuScript>();
        name = menu.playerName;

        input = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        input.text = name;
    }
}
