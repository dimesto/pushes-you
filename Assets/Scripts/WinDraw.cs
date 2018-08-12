using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinDraw : MonoBehaviour {

    Text txt;
    MainMenuScript menu;

    public float timeLeft = 5.0f;
    float timein = 0.0f;

    // Use this for initialization
    void Start () {
        txt = GetComponent<Text>();
        menu = GameObject.FindObjectOfType<MainMenuScript>();
    }
	
	// Update is called once per frame
	void Update () {
        timein += Time.deltaTime;
        txt.text = "winer :\n" + menu.playerwin + "\n(" + ((int)(timeLeft - timein)) + ")" ;
        if((timeLeft - timein) < 0)
        {
            menu.disconect();
        }
	}
}
