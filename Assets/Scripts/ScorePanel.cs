using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ScorePanel : MonoBehaviour
{

    public GameObject ScoreEntryPrefab;
    
    public Dictionary<string,int> Scores;

    public GameObject winCanvas;

	// Use this for initialization
	void Start () {
        Scores = new Dictionary<string, int>();

    }
	
	// Update is called once per frame
	public void add (string name)
    {
        if(Scores.ContainsKey(name))
        {
            Scores[name]++;
            if (Scores[name] >= 10)
            {
                MainMenuScript menu = FindObjectOfType<MainMenuScript>();
                menu.playerwin = name;
                winCanvas.SetActive(true);
            }
        }
        else
        {
            Scores.Add(name, 1);
        }

        Dictionary<string, int> sorted = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> item in Scores.OrderByDescending(i => i.Value))
        {
            sorted.Add(item.Key, item.Value);
        }
        Scores = sorted;
    }

	void Update ()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        List<string> listOfKeys = Scores.Keys.ToList();
        for (int i = 0; i < Scores.Count && i < 5; i++)
        {
            GameObject go = GameObject.Instantiate(ScoreEntryPrefab, this.transform);
            go.GetComponent<scoreEntry>().id = i;
            go.GetComponent<scoreEntry>().namestr = listOfKeys[i];
            go.GetComponent<scoreEntry>().scorestr = Scores[listOfKeys[i]].ToString();
        }
    }
}
