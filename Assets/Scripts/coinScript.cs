using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinScript : MonoBehaviour {
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void coinCreator(GameObject coin)
    {
        float coinX = 0;
        float coinY = 0;
        Vector2 coinPosition;
        coinX = Random.Range(500, 1400);
        coinY = Random.Range(200, 700);
        coinPosition = new Vector2(coinX, coinY);
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(coinPosition));
        coin.transform.position = hit.point;
    }

}
