using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public int rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");                                            //declares a variable to get the input from the user for horizontal input
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);                 //Rotates the camera angle on the axis 0, 1, 0. at a speed of 1
    }
}
