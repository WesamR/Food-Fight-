using UnityEngine;
using UnityEngine.InputSystem;

public class HealthSystem : MonoBehaviour
{
    public int currentCalories;
    public int maxCalories = 100;
    public bool isWinner = false;
    private bool isDead = false;

    private GameObject caloriesDisplayObject;
    private TextMesh caloriesTextMesh;
    public Animator ani;
    public Psound pam2;

    // Start is called before the first frame update
    void Start()
    {

        ani= GetComponent<Animator>();
        // Create a new GameObject for the TextMesh
        caloriesDisplayObject = new GameObject("CaloriesDisplay");
        caloriesTextMesh = caloriesDisplayObject.AddComponent<TextMesh>();

        // Configure the TextMesh
        caloriesTextMesh.text = currentCalories + "/" + maxCalories;
        caloriesTextMesh.characterSize = 0.1f;
        caloriesTextMesh.fontSize = 64;
        //caloriesTextMesh.color = Color.white;
        //assign random color to text
        caloriesTextMesh.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        caloriesTextMesh.anchor = TextAnchor.MiddleCenter;  // Center the text

        // Set the TextMesh to be a child of the player
        caloriesDisplayObject.transform.SetParent(transform);

        // Position the TextMesh above the player character
        caloriesDisplayObject.transform.localPosition = new Vector3(0, 1, 0);

         pam2 = GetComponent<Psound>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the caloriesDisplayObject stays above the player
        caloriesDisplayObject.transform.localPosition = new Vector3(0, 1, 0);
        caloriesTextMesh.text = currentCalories + "/" + maxCalories;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Player collideded.");
        if (collision.gameObject.CompareTag("Food") )
        {
            FruitObj food = collision.gameObject.GetComponent<FruitObj>();

            if (!food.bulletState) return;

            if (food != null)
            {
                int propertyValue = food.calories; // Replace 'property' with the actual property name
                Eat(propertyValue);
               
                Destroy(collision.gameObject);
                
            }
        }
    }


    /// <summary>
    /// This method is called when the player eats food.
    /// If the player's calories exceed the maximum, the player is dead.
    /// </summary>
    /// <param name="calories">The calories value of the food.</param>
    public void Eat(int calories)
    {
        currentCalories += calories;
        pam2.EatSound();
        if (currentCalories >= maxCalories)
        {

            currentCalories = maxCalories;
            //isDead = true;
            ani.SetBool("isSleeping",!isDead);
            pam2.DeadSound();
            
        }
    }

    /// <summary>
    /// Returns the player's current death status.
    /// </summary>
    public bool IsDead
    {
        get { return isDead; }
    }

    /// <summary>
    /// Debug method to unalive the player.
    /// </summary>
    /// <param name="context"></param>
    public void Unalive(InputAction.CallbackContext context)
    {
        if (context.performed)
            Eat(10);
        //isDead = true;
        //Debug.Log("Player is dead");
    }

}
