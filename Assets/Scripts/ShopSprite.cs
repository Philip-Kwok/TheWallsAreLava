using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopSprite : MonoBehaviour {
    
    public Button[] shopButtons;
    public Button[] shopBackgroundButtons;
    public static Sprite[] ballSprites;
    private static string[] ballKeys;
    private static bool[] ballStates = new bool[15];
    public static int selectedSpriteIndex = 1;


    // Use this for initialization
    void Start () {
        string key = "ballSpriteIndex";
        bool haskey = PlayerPrefs.HasKey(key);
        if (haskey)
        {
            selectedSpriteIndex = PlayerPrefs.GetInt(key);
        }
        else
        {
            selectedSpriteIndex = 1;
            PlayerPrefs.SetInt(key, selectedSpriteIndex);
        }
        
        ballKeys = new string[15] { "9gag","default", "blue", "green", "grey", "pink", "purple", "red", "teal", "white", "Yellow","Camo","Dotted","Joker","Rainbow"};
        checkState();
        //setState();
        
        
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        { SceneManager.LoadScene(0); }
    }

    public static void setActiveSprite(int choice)
    {
        ballStates[0] = true;
        ballStates[1] = true;
        DialogScript dialogScript = new DialogScript();
        if(ballStates[choice])
        {
            selectedSpriteIndex = choice;
            string key = "ballSpriteIndex";
            PlayerPrefs.SetInt(key, selectedSpriteIndex);
        }
        else
        {
            int cost;
            if(choice<10)
            {
                cost = 100;
            }
            else
            {
                cost = 200;
            }
                int coins;
                coins = GameOverScript.getCoins();
                if(coins>=cost)
                {
                    coins -= cost;
                    string key = "coins";
                    PlayerPrefs.SetInt(key, coins);
                    ballStates[choice] = true;
                    PlayerPrefs.SetInt(ballKeys[choice], 1);
                }
                else if(coins<cost)
                {
                    dialogScript.showDialog("You don't have enough coins. Sorry");
                }
        }

    }

    public static Sprite getActiveSprite()
    {
        ballSprites = Resources.LoadAll<Sprite>("BallImages");
        string key = "ballSpriteIndex";
        bool haskey = PlayerPrefs.HasKey(key);
        if (haskey)
        {
            selectedSpriteIndex = PlayerPrefs.GetInt(key);
        }
        else
        {
            selectedSpriteIndex = 0;
            PlayerPrefs.SetInt(key, selectedSpriteIndex);
        }
        return ballSprites[selectedSpriteIndex];
    }


    void checkState()
    {
        for (int i = 0; i < 10; i++)
        {
            bool haskey = PlayerPrefs.HasKey(ballKeys[i]);
            if (haskey)
            {
                if (PlayerPrefs.GetInt(ballKeys[i]) == 1 || PlayerPrefs.GetInt(ballKeys[i])==0)
                {
                    ballStates[i] = true;
                }
                else
                {
                    ballStates[i] = false;
                }
            }
            else if (i ==1)
            {
                PlayerPrefs.SetInt(ballKeys[0],1);
            }
            else
            {
                PlayerPrefs.SetInt(ballKeys[i], 0);
                ballStates[i] = false;
            }
        }
    }


    }


