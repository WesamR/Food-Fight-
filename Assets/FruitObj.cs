using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitObj : MonoBehaviour
{
    public bool bulletState = false;
    public int calories = 10;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ancaclamm");
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Food")
        {
            bulletState = false;
        }
    }
}
