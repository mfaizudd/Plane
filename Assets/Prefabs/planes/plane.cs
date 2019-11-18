using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class plane : MonoBehaviour {
    
    public float speed = 1;
    public int lives = 3;
    public GameObject bullet;
    public float powerUps = 0;
    public float ShootingRateSetting = .5f;
    public GameObject explosion;
    public int score = 0;
    public Text scoreText;

    private float shootingRate;
    private float acceleration = 2f;
    private int highScore = 0;


	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        shootingRate = ShootingRateSetting;
        highScore = PlayerPrefs.GetInt("highscore", 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouse;
        if (Input.GetButton("Fire1"))
        {
            Shoots();
        }
        else
        {
            shootingRate = .5f;
        }
        if(lives<=0)
        {
            Destroy(gameObject);
            if (lives <= 0)
            {
                if(score>highScore)
                {
                    PlayerPrefs.SetInt("highScore", score);
                }
                Destroy(gameObject);
                Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 2), Quaternion.identity);
                SceneManager.LoadScene("MainMenu");
            }
        }
        scoreText.text = string.Format("Score: {0}", score);
    }

    public void UpdateShootingRate()
    {
        shootingRate = ShootingRateSetting - powerUps;
    }

    private void Shoots()
    {
        shootingRate -= acceleration * Time.deltaTime;
        if (shootingRate <= 0)
        {
            Instantiate(bullet, new Vector3(transform.position.x + 3f, transform.position.y + .4f, -11), Quaternion.identity);
            UpdateShootingRate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            lives--;
            Destroy(collision.gameObject);
            Instantiate(explosion, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 2), Quaternion.identity);
            score += 10;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.8f);
    }
}
