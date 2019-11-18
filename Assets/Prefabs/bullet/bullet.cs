using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject exploison;

    float speed = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            var enemyObject = collision.gameObject.GetComponent<enemy>();
            if(enemyObject!=null)
            {
                if (enemyObject.Lives-1 > 0) { 
                    Destroy(gameObject);
                    var pos = transform.position;
                    Instantiate(exploison, new Vector3(pos.x, pos.y, -5), Quaternion.identity);
                }
                enemyObject.Lives--;
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
