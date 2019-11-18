using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public float speed = 1;
    public int lives = 7;
    public GameObject drop;
    public GameObject explosion;

    private GameObject plane;

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            if(lives<=0)
            {
                Kill();
            }
        }
    }
    public GameObject bullet;
    public float BulletSpeed = 3f;
    private float bulletSpeed;


    // Use this for initialization
    void Start () {
        bulletSpeed = BulletSpeed;
        plane = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float transx = speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x - transx, transform.position.y,-1);
        bulletSpeed -= Time.deltaTime;
        if (bulletSpeed <= 0)
        {
            Instantiate(bullet, new Vector3(transform.position.x - 2f, transform.position.y-1f, -2), Quaternion.identity);
            bulletSpeed = BulletSpeed;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        var drops = Random.Range(1, 10);
        if(drops<3)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        Instantiate(explosion, new Vector3(transform.position.x, transform.position.y,2), Quaternion.identity);
        if(plane!=null)
        {
            plane.GetComponent<plane>().score += 10;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
