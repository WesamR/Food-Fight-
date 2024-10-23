using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject healthBarPrefab;  // Reference to the health bar prefab
    private GameObject healthBarInstance;
    private Transform healthBarTransform;
    public Vector3 healthBarOffset;  // Offset for positioning the health bar
    public float maxHealth = 100f;
    public float currentHealth;
    private Image healthBarFill;

    void Start()
    {
        // Initialize player health
        currentHealth = maxHealth;

        // Spawn the health bar above the player
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + healthBarOffset, Quaternion.identity);

        // Get the fill image component of the health bar
        healthBarFill = healthBarInstance.transform.Find("HealthBarFill").GetComponent<Image>();

        // Keep track of the health bar's transform to update position
        healthBarTransform = healthBarInstance.transform;
    }

    void Update()
    {
        // Update the health bar position to follow the player
        if (healthBarInstance != null)
        {
            healthBarTransform.position = transform.position + healthBarOffset;
        }
    }

    // Function to take damage (or in your case, increase health)
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0) currentHealth = 0;

        // Update the health bar fill amount
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }

    // Function to heal or increase health (when hit by food)
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        // Update the health bar fill amount
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
}
