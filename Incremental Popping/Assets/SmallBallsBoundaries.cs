using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBallsBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    public GameObject obj;

    private void Start()
    {
        screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        var posY = screenBounds.y - 1.1f;
        var posX = screenBounds.x;
        
        var collider = Instantiate(obj);
        collider.transform.position = new Vector3(0, posY, 0);
        
        var collider1 = Instantiate(obj);
        collider1.transform.position = new Vector3(0, -posY, 0);
        
        var collider2 = Instantiate(obj);
        collider2.transform.position = new Vector3(posX, 0, 0);
        collider2.transform.rotation = Quaternion.Euler(0, 0, 90f);
        
        var collider3 = Instantiate(obj);
        collider3.transform.position = new Vector3(-posX, 0, 0);
        collider3.transform.rotation = Quaternion.Euler(0, 0, 90f);
    }
}
