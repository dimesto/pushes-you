using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ipConnect : MonoBehaviour {

    public MainMenuScript menu;

    string ip;

    InputField input;

    // Use this for initialization
    void Start () {
        input = this.GetComponent<InputField>();
    }
	
	// Update is called once per frame

    public void UpdateValue()
    {
        Match valid = Regex.Match(input.text, "^((2((5[0-5])|([0-4][0-9])))|(1?[0-9]?[0-9]).){4}((2((5[0-5])|([0-4][0-9])))|(1?[0-9]?[0-9]))$");
        if (valid.Success)
            ip = input.text;
    }

    public void Connect()
    {
        menu.ConnectToServerLan(ip);
    }

}
