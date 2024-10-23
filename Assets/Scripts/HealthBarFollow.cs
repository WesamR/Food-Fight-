using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{   public Transform player; // Reference to the player's transform
    public Vector3 offset;   // Offset from the player's position (above the head)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (player != null)
        {
            // Update the position of the health bar to follow the player
            Vector3 newPos = player.position + offset;
            transform.position = newPos;
        }  
    }
}
