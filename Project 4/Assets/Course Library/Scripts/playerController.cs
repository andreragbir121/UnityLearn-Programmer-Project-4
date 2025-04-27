using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody playerRB;                     //declares a Rigidbody Variable to assign the player rigid body in code 
    private GameObject focalPoint;                  //create a GameObject variable for the camera focal Point
    public float speed = 5.0f;                      //float variable for assigning the speed of the player
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();                   //gets the game component of the player in the game
        focalPoint = GameObject.Find("Focal Point");            //finds the Focal Point of the camera from within the game
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");                     //gets the input axis for vertical input

        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);         //takes the playerRB var and apply force to it based on the camera focal point and speed and the input from user

        powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)                             //onTriggerEnterMethod created for detecting when a collision is triggered
    {
        hasPowerup = true;
        powerupIndicator.gameObject.SetActive(true);                        //sets the powerupIndicator to active in the game so that the player knows that they have collected the powerup
        Destroy (other.gameObject);
        StartCoroutine(PowerUpCountDown());                                 //startCoroutine, is used to start the powerUpCountdown outside the IEnumerator

    }

    

// IEnumerator is an interface in C# used for iterating through collections or creating coroutines in Unity.
// It allows pausing execution using yield return (e.g., yield return null to wait a frame, or yield return new WaitForSeconds(1) to delay).
// Essential for asynchronous or timed tasks like animations, delays, or staggered actions.
    IEnumerator PowerUpCountDown(){
        yield return new WaitForSeconds(7);                 //allows us to run this timer outside our loop
        hasPowerup = false;                                 //once timer runs out from yeild function then hasPowerup resets to false
        powerupIndicator.gameObject.SetActive(false);       //deactivates the indicator which means the powerup has ended


    }




     private void OnCollisionEnter(Collision collision)  {                  //onCollisionEnter created for when collision is happening 

        Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();  //create a rigidbody variable to apply a collision
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;  //creates a vector3 enabling the enemy to bounce away from the player when collided with

        enemyRigidBody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);    //apply a force to the enemy rigid body using the awayFromPlayer variable and apply a force type of impulse
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup){        //compares the tag applied to the enemy 
            Debug.Log("Collided with : " + collision.gameObject.name + "With Powerup Set to: " + hasPowerup);      //when collided the console will output this line within it
        }

    }
}


