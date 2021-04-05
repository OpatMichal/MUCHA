using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float flyingSpeed;
    public float horizontalFlyingSpeed;
    public float verticalFlyingSpeed;
    public float maxAngle = 30;

    //private readonly float verticalMove = 2;

    Vector3 playerPosition;
    Vector3 currentRotation;
    Vector3 destinationRotation;

    // private void Start()
    // {

    // }
    void Update()
    {
        Debug.Log("otodane: " + Input.acceleration);
        Flying();

    }

    private void Flying()
    {
        playerPosition = transform.position;
        currentRotation = transform.eulerAngles;

        playerPosition.x += Input.acceleration.x * horizontalFlyingSpeed * Time.deltaTime;
        playerPosition.x = Mathf.Clamp(playerPosition.x, -2.0f, 2.0f);

        playerPosition.y += Input.acceleration.z * horizontalFlyingSpeed * Time.deltaTime;
        playerPosition.y = Mathf.Clamp(playerPosition.y, -0.5f, 4.5f);

        transform.position = playerPosition;

        destinationRotation = new Vector3(-Input.acceleration.z * maxAngle, 0, -Input.acceleration.x * maxAngle);
        currentRotation = new Vector3(Mathf.LerpAngle(currentRotation.x, destinationRotation.x, 1), 0, Mathf.LerpAngle(currentRotation.z, destinationRotation.z, 1));

        transform.eulerAngles = currentRotation;

        transform.Translate(transform.forward * Time.deltaTime * flyingSpeed);

    }

}
