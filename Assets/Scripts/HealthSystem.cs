using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthSystem : MonoBehaviour
{
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDead
    {
        get { return isDead; }
    }

    public void Unalive(InputAction.CallbackContext context)
    {
        isDead = true;
        //Debug.Log("Player is dead");
    }

}
