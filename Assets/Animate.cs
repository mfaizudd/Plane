using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {
    public Texture2D[] frames;
    float framePersecond = 12.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int index = (int)(Time.time * framePersecond);
        index = index % frames.Length;
        GetComponent<Renderer>().material.mainTexture = frames[index];
	}
}
