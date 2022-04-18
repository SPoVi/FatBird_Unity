//using System.Collections;           // list of objects. NOT USING HERE
//using System.Collections.Generic;
using UnityEngine;

// Name class must match filename
public class FatBird : MonoBehaviour // reuse Monobehaviour
{
    // ------------ GLOBAL VARS ----------------------
    Vector3 _initialPosition;                                   // _ means that is for private use
    private bool _birdWasLaunched;                              // By default = False
    private float _timeSittingAround;                           // Frames / sec

    // SerializeField allows to modify param in Unity
    [SerializeField] private float _launchPower = 500;          // Private - vel bird launched
        

    // Margins of movement to reset position - private (underscore)
    int _horizontalLeft = -10;
    int _horizontalright = 10;
    int _verticalUp = 10;
    int _verticalDown = -10;
    // Max velocity bird can get
    int _maxTimeSittingAround = 3;


    // Method - When program start save initial position to reuse later
    private void Awake() {
        _initialPosition = transform.position;
    }

    // Method - Gets call in a loop
    private void Update() {

        // Render a Line
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        


        // Velocity control
        if (_birdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) // very slowly movement
        {
            _timeSittingAround += Time.deltaTime;   // Frame/sec
        }

        // Reset to initial position if vertical pos > 10 or pos < -10.
        // Reset to initial position if horizontal pos > 10 or pos < -10.
        if (transform.position.y > _verticalUp ||
            transform.position.y < _verticalDown ||
            transform.position.x > _horizontalright ||
            transform.position.x < _horizontalLeft ||
            _timeSittingAround > _maxTimeSittingAround)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
    // Method - Gets call every time we click on the bird
    private void OnMouseDown() 
    {
        GetComponent<SpriteRenderer>().color = Color.red;   // Change color of bird
        GetComponent<LineRenderer>().enabled = true;        // Make visible de rendered line
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
        // Set to true that bird is launched
        _birdWasLaunched = true;
        // Make invisible the rendered line
        GetComponent<LineRenderer>().enabled = false;

    }

    // Method - Drag the bird with the mouse
    private void OnMouseDrag() 
    {   
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}



