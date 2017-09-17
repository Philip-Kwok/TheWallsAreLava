using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {
    public Button crap;
    public int SceneNumber;
    // Use this for initialization

    void Start()
    {
        Debug.Log("Penis");
        crap.onClick.AddListener(Restart);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        { SceneManager.LoadScene(0); }
    }
    void Restart()
    {
        Debug.Log("vagina");
        SceneManager.LoadScene(0);
    }
}
