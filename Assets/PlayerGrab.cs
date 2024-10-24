using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    private CharInput _charInput;
    private Vector2 throwDir;

    public Transform grabPoint;  // Reference to the grab point on the player
    public Transform throwPoint;
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
            ThrowFood(throwDir, _charInput.FacingDir);
        }
    }
    public void Aim(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        throwDir = context.ReadValue<Vector2>();
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

    void ThrowFood(Vector2 throwDir, int facingDir)
    {
        if (grabbedFood != null)
        {
            Rigidbody2D foodRb = grabbedFood.GetComponent<Rigidbody2D>();
            CircleCollider2D foodCol = grabbedFood.GetComponent<CircleCollider2D>();

            if (foodRb != null)
            {
                foodRb.isKinematic = false;
            }

            // put food outside of player collider
            //float fX = GetComponent<Transform>().position.x + (throwPoint.transform.localPosition.x * throwDir);
            float fX = GetComponent<Transform>().position.x + ((GetComponent<CapsuleCollider2D>().size.x
                + grabbedFood.GetComponent<CircleCollider2D>().radius + 0.1f) * facingDir);
            float fY = throwPoint.transform.position.y;
            grabbedFood.transform.position = new Vector3(fX, fY);//throwPoint.transform.position;

            //Vector2 throwDirection = new Vector2(throwDir*throwForce, 0);
            if (throwDir == Vector2.zero) foodRb.AddForce(new Vector2(facingDir * throwForce, 0), ForceMode2D.Impulse);
            else foodRb.AddForce(throwDir * throwForce, ForceMode2D.Impulse);
            //foodRb.velocity = throwDirection;
            foodCol.enabled = true;
            grabbedFood = null;
        }

    }

}
