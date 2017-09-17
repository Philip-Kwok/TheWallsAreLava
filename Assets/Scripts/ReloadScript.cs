using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScript : MonoBehaviour {
    public Button reloadButton;
	// Use this for initialization
	void Start () {
        reloadButton.onClick.AddListener(buttonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void buttonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
