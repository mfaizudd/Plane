using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {
    public GameObject[] clouds;
    public float CloudDelay = 10f;
    private float cloudDelay;

	// Use this for initialization
	void Start () {
        cloudDelay = CloudDelay;
    }
	
	// Update is called once per frame
	void Update () {
        int index = Random.Range(0, clouds.Length);
        cloudDelay -= Time.deltaTime;
        var cloud = clouds[index];
        if(cloudDelay<=0)
        {
            float miny = transform.localScale.y / 2;
            float maxy = -transform.localScale.y / 2;
            float scale = Random.Range(.5f, .8f);
            cloud.transform.localScale = new Vector2(scale, scale);
            Instantiate(cloud, new Vector3(transform.position.x, Random.Range(miny, maxy), 9), Quaternion.identity);
            cloudDelay = Random.Range(5,CloudDelay);
        }
	}
}
