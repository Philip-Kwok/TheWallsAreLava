using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour {
    public Rigidbody2D ball;
    public SpriteRenderer ballSpriteRenderer;
    float thrust = 10000;
    public Text points;
    private static int num;
    private bool check = true;
    public Text coinLabel;
    private static int coins;
    private float coinTimer;

	// Use this for initialization
	void Start () {
        ballSpriteRenderer.sprite = ShopSprite.getActiveSprite();
        ball.AddForce(transform.up*thrust);
        ball.AddForce(transform.right*thrust);
        ball.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        num = 0;
        coins = 0;
        coinTimer = Time.time + 5;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time>coinTimer)
        {
            coinScript.coinCreator(GameObject.FindGameObjectWithTag("coin"));
            coinTimer += 5;
        }

	}

    public static int getCoins()
    {
        return coins;
    }

    public static int getScore()
    {
        return num;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.CompareTag("Shield") && check)
        {
            num++;
            points.text = num + "";
            ball.velocity *= 1.02f;
            check = false;
            
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        check = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "coin")
        {
            coins++;
            num += 5;
            coinLabel.text = coins + "";
            coinScript.coinCreator(collision.gameObject);
        }


    }
}
