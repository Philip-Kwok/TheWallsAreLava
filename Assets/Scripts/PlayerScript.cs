using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    public GameObject shield;

    public static int rubber;
    public Text rubberLabel;
    float timer;
    public static Vector3 start;
    public static Vector3 end;
    bool check=false;

    // Use this for initialization
    void Start() {
        timer = Time.time + 1;
        rubber = 200;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { SceneManager.LoadScene(0); }
        updateRubber();
    }

    private void OnMouseDrag()
    {
        if (rubber > 0)
        {
            drawWall2();
        }
    }

    

    void drawWall()
    {
        if (rubber > 0)
        {  
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Instantiate(shield, hit.point, Quaternion.identity);
            rubber--;
           
        }
    }

    void drawWall2()
    {
        float length;
        float shieldX;
        float shieldY;
        float width;
        Vector2 position;
        if(check)
        {
            start = end;
        }
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        end = hit.point;
        length = Mathf.Sqrt(
            Mathf.Pow((end.x - start.x), 2)
            + Mathf.Pow((end.y - start.y), 2));
        width = 10;
        float tan = Mathf.Atan2(start.y - end.y, start.x - end.x);
        float angle = tan * (180 / Mathf.PI);
        shieldX = (start.x + end.x) / 2;
        shieldY = (start.y + end.y) / 2;
        position = new Vector2(shieldX, shieldY);
        shield.transform.localScale = new Vector2(length, width);
        rubber--;
        
        Instantiate(shield, position, Quaternion.Euler(0, 0, angle));
        if(!check)
        {
            check = true;
        }
    }

    private void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        start = hit.point;
    }

    private void OnMouseUp()
    {
        check = false;
    }
    //private void OnMouseDown()
    //{
    //    RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
    //    start = hit.point;

    //}

    //private void OnMouseUp()
    //{
    //    float length;
    //    float shieldX;
    //    float shieldY;
    //    float width;
    //    Vector2 position;

    //    RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
    //    end = hit.point;
    //    length = Mathf.Sqrt(
    //        Mathf.Pow( (end.x - start.x) , 2)
    //        + Mathf.Pow((end.y - start.y), 2));
    //    width = 10;
    //    float tan = Mathf.Atan2(start.y - end.y, start.x - end.x);
    //    float angle = tan * (180 / Mathf.PI);
    //    shieldX = (start.x + end.x) / 2;
    //    shieldY = (start.y + end.y) / 2;
    //    position = new Vector2(shieldX, shieldY);
    //    shield.transform.localScale = new Vector2(length,width);

    //    Instantiate(shield, position, Quaternion.Euler(0,0,angle));
    //}

    private void updateRubber()
    {
if(Time.time>timer)
        {
            rubber ++;
            timer += 0.2f;
        }
        rubberLabel.text = rubber + "";
    }
}


