using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenuScript : MonoBehaviour {
    public Button menuButton;
	// Use this for initialization
	void Start () {
        menuButton.onClick.AddListener(buttonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void buttonClick()
    {
        SceneManager.LoadScene(0);
    }
}
