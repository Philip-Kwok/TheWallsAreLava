using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

    public Button button;
    bool state = true;
    public AudioSource music;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(pause);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void pause()
    {
        if (state == true)
        {
            music.mute = true;
            Time.timeScale = 0;
            state = false;
        }
        else
        {
            music.mute = false;
            Time.timeScale = 1;
            state = true;
        }
    }
}
