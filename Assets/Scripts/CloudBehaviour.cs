using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour {
    public float velocity = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = velocity * Time.deltaTime;
        transform.position = new Vector3(transform.position.x - distance, transform.position.y,9);
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
