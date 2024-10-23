using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    private CharInput _charInput;

    public Transform grabPoint;  // Reference to the grab point on the player
    public float grabRange = 2f; // Distance the player can grab food
    private GameObject grabbedFood; // Currently held food
    public float throwForce = 10f; 

    // Start is called before the first frame update
    void Start()
    {
        try { _charInput = GetComponent<CharInput>(); }
        catch { Debug.Log("no charinput"); }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))  // Press 'E' to grab food
        //{
        //    if (grabbedFood == null)  // If not holding food, try to grab it
        //    {
        //        TryGrabFood();
        //    }
        //    else  // If already holding food, drop or throw it
        //    {
        //        ThrowFood();
        //    }
        //}
    }

    public void GrabThrow(InputAction.CallbackContext context)
    {
        if (!context.action.triggered) return;
        if (grabbedFood == null)  // If not holding food, try to grab it
        {
            TryGrabFood();
        }
        else  // If already holding food, drop or throw it
        {
            ThrowFood(_charInput.FacingDir);
        }
    }


    void TryGrabFood()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, grabRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Food"))
            {
                grabbedFood = hitCollider.gameObject;
                grabbedFood.transform.position = grabPoint.position;
                grabbedFood.transform.parent = grabPoint;

                Rigidbody2D foodRb = grabbedFood.GetComponent<Rigidbody2D>();
                CircleCollider2D foodCol = grabbedFood.GetComponent<CircleCollider2D>();
                if (foodRb != null)
                {
                    foodRb.isKinematic = true; 
                    foodCol.enabled = false;
                    foodRb.velocity = Vector2.zero; // Ensure no residual forces
                }

            
                break;
            }
        }
    }

    void ThrowFood(int throwDir)
    {
        if (grabbedFood != null)
        {
            Rigidbody2D foodRb = grabbedFood.GetComponent<Rigidbody2D>();
            CircleCollider2D foodCol = grabbedFood.GetComponent<CircleCollider2D>();
            if (foodRb != null)
            {
                foodRb.isKinematic = false;
            }
            grabbedFood.transform.parent = null;
            Vector2 throwDirection = new Vector2(transform.localScale.x*throwDir, 0).normalized;
            foodRb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
            foodCol.enabled = true;
            grabbedFood = null;

        }

    }

}
