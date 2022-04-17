//using System.Collections;           // list of objects. NOT USING HERE
//using System.Collections.Generic;
using UnityEngine;

// Name class must match filename
public class FatBird : MonoBehaviour // reuse Monobehaviour
{
    // Method - Gets call every time we click on bird
    private void OnMouseDown() 
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Method - Gets call every time we free the click button
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Method - Drag the bird with the mouse
    private void OnMouseDrag() 
    {   
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
}

