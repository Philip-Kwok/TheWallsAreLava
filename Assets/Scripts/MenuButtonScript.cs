using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public Button menuButton;
    public int Scene;
    // Use this for initialization
    
    void Start () {
        menuButton.onClick.AddListener(buttonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void buttonClick()
    {
        SceneManager.LoadScene(Scene);
    }

  
    
}
