using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundControlScript : MonoBehaviour {
    private static bool check=true;
    public  Sprite on;
    public  Sprite off;
    public  Button soundButton;
    public  AudioSource music;

	// Use this for initialization
	void Start () {
        soundButton.onClick.AddListener(buttonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buttonClick()
    {
        check = !check;
        if(check)
        {
            music.mute = !music.mute;
            soundButton.image.sprite = on;
        }
        else
        {
            music.mute=!music.mute;
            soundButton.image.sprite = off;
        }
    }
}
