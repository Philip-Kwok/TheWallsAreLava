using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopButtonScript : MonoBehaviour {
    public Button button;
    public int index;
	// Use this for initialization
	void Start () {
        button.onClick.AddListener(click);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void click()
    {
        ShopSprite.setActiveSprite(index);
    }
}
