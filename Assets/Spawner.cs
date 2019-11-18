using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    private float timeLeft = 2f;
    public plane player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(player.lives>0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                float miny = transform.localScale.y / 2;
                float maxy = -transform.localScale.y / 2;
                Instantiate(enemy, new Vector3(transform.position.x, Random.Range(miny, maxy),-1), Quaternion.identity);
                timeLeft = 2f;
            }
        }
	}
}
