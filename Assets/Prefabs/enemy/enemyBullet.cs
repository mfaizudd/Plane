using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {
    public GameObject exploison;
    public float speed = 7;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, -2);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<plane>();
            if(player!=null)
            {
                if(player.lives>0)
                {
                    Destroy(gameObject);
                    var pos = transform.position;
                    Instantiate(exploison, new Vector3(pos.x, pos.y, -5), Quaternion.identity);
                }
                player.lives--;
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
