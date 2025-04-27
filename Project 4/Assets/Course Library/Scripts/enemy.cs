using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3.0f;          //create a float speed to assign to the enemy movement
    private Rigidbody enemyRB;          //creates a Rigidbody variable for storing enemey rigidbody
    private GameObject player;          //creates a GameObeject variable for storing the player from the game
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();            //gets the rigid body componenet from the enemy and assigns it to the variable
        player = GameObject.Find("Player");             //locates the Player within the game an assigns it to the player variable declared above
    }   

    // Update is called once per frame
    void Update()
    {

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);                                               //  uses the enemyRB to assign force to the game and minus the position of the player so 
                                                                                                //  that the enemy follows the player. the .normalized helps to keep the enemy at a constant 
                                                                                                // speed and not speed up or slow down 

        if (transform.position.y < -10){                                                        //if the position of the enemy is less than -10 on the y axis then:
            Destroy(gameObject);                                                                //Destroy the object
        }

                                                                                                
    }
}
