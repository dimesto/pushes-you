using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleActiv : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	public void toogle ()
    {
        target.SetActive(!target.activeSelf);
	}
}
