using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;  // Speed of platform movement
    [SerializeField] private float moveDistance = 3f;  // Distance the platform moves
    [SerializeField] private bool moveHorizontally = true;  // Choose between horizontal or vertical movement

    private Vector3 startingPosition;
    private bool movingRight = true;

    void Start()
    {
        startingPosition = transform.position;  // Save the platform's initial position
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Move horizontally
        if (moveHorizontally)
        {
            if (movingRight)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                if (transform.position.x > startingPosition.x + moveDistance)
                {
                    movingRight = false;  // Reverse direction
                }
            }
            else
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                if (transform.position.x < startingPosition.x - moveDistance)
                {
                    movingRight = true;  // Reverse direction
                }
            }
        }
        // Move vertically
        else
        {
            if (movingRight)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                if (transform.position.y > startingPosition.y + moveDistance)
                {
                    movingRight = false;  // Reverse direction
                }
            }
            else
            {
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;
                if (transform.position.y < startingPosition.y - moveDistance)
                {
                    movingRight = true;  // Reverse direction
                }
            }
        }
    }
}
