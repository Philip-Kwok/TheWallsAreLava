using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOverScript : MonoBehaviour {
    public Text FinalScore;
    public Text GOMessage;
    public Button RestartButton;
    public Text HighScore;
    public Text coinLabel;
    private static int coins;
    private int score;
    static int gameNum=0;
	// Use this for initialization
	void Start () {
        score = BallBehavior.getScore();
        FinalScore.text = score.ToString();
        RestartButton.onClick.AddListener(Restart);
        
        SetHighscore(score);
        setCoins(BallBehavior.getCoins());
        checkScore(score);
        gameNum++;
        if(score == 99)
        {
            ShopSprite.setActiveSprite(0);
        }
        if(gameNum==10)
        {
            Advertisement.Show();
            gameNum = 0;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void checkScore(int score)
    {
        if (score < 20)
        {
            GOMessage.text = "GG Loser.";
        }
        else if(score >=20 && score <40)
        {
            GOMessage.text = "Not bad. \nStill a loser though.";
        }
        else if(score >=40 && score < 60)
        {
            GOMessage.text = "Nice!";
        }
        else if(score >=60 && score < 80)
        {
            GOMessage.text = "I am not worthy. Good Game!";
        }
        else
        {
            GOMessage.text = "Are you hacking?";
        }
    }
    void setCoins(int amount)
    {
        string key = "coins";
        bool haskey = PlayerPrefs.HasKey(key);
        if(haskey)
        {
            coins = amount + PlayerPrefs.GetInt(key);
            PlayerPrefs.SetInt(key, coins);
        }
        else
        {
            PlayerPrefs.SetInt(key, amount);
            coins = amount;
        }
        coinLabel.text = coins + "";

    }

    public static int getCoins()
    {
        string key = "coins";
        bool haskey = PlayerPrefs.HasKey(key);
        if (haskey)
        {
            coins = PlayerPrefs.GetInt(key);
            PlayerPrefs.SetInt(key, coins);
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
        return coins;
    }

    void SetHighscore(int score)
    {
        string key = "highscore";
        bool haskey = PlayerPrefs.HasKey(key);
        int highscore = score;
        if (haskey)
        {
            highscore = PlayerPrefs.GetInt(key);
            if (score>highscore)
            {
                PlayerPrefs.SetInt(key, score);
                highscore = score;
                PlayerPrefs.Save();
            }
            
        }
        else
        {
            PlayerPrefs.SetInt(key, score);
        }
        HighScore.text = "High Score: " + highscore.ToString();
    }
}
