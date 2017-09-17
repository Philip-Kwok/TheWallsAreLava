using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour
{
    public Button QuitButton;
    // Use this for initialization

    void Start()
    {
        QuitButton.onClick.AddListener(buttonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void buttonClick()
    {
        Application.Quit();
    }

}
