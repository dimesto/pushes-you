using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class scoreEntry : MonoBehaviour {

    public int id;

    public Text name;
    public Text score;

    public string namestr;
    public string scorestr;

    ScorePanel panel;

    void Start()
    {

        //List<string> lKey = panel.Scores.Keys.ToList();

        name.text = namestr;
        score.text = scorestr;
    }
}
