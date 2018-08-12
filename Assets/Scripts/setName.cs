using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setName : MonoBehaviour
{

    public MainMenuScript menu;
    InputField input;

    // Use this for initialization
    void Start()
    {
        input = this.GetComponent<UnityEngine.UI.InputField>();
    }
    public void Set()
    {
        menu.playerName = input.text; 
    }
}
