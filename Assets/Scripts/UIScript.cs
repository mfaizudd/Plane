using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {

    public GameObject[] lives;
    public GameObject plane;

    private int totalLive;

	// Use this for initialization
	void Start () {
        totalLive = plane.GetComponent<plane>().lives;
	}

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < totalLive; i++)
        {
            lives[i].SetActive(false);
        }
        if (plane != null)
        {
            for (int i = 0; i < plane.GetComponent<plane>().lives; i++)
            {
                lives[i].SetActive(true);
            }
        }
	}
}
