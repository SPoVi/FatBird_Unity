//using System.Collections;           // list of objects. NOT USING HERE
//using System.Collections.Generic;
using UnityEngine;

// Name class must match filename
public class FatBird : MonoBehaviour // reuse Monobehaviour
{
    Vector3 _initialPosition; // _ means that is for private use

    [SerializeField] private float _launchPower = 600;       // Private - vel bird launched
        // SerializeField allows to modify param in Unity

    // Method - When program start save initial position to reuse later
    private void Awake() {
        _initialPosition = transform.position;
    }

    // Method - Gets call in a loop
    private void Update() {

        if (transform.position.y > 10){
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
    // Method - Gets call every time we click on the bird
    private void OnMouseDown() 
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Method - Gets call every time we stop clicking on the bird
    private void OnMouseUp()
    {
        // Change color
        GetComponent<SpriteRenderer>().color = Color.white;
        // Movement to rigid body
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        // Reset to 1 gravity
        GetComponent<Rigidbody2D>().gravityScale =1;

    }

    // Method - Drag the bird with the mouse
    private void OnMouseDrag() 
    {   
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}


