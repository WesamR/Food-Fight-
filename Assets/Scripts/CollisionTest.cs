using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroys the fruit clone the player touches.
        }
    }
}

