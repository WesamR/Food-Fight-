using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefab;
    [SerializeField] float secondSpawn = 5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()
    {
        while (true)
        {
            var wanted = UnityEngine.Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y);
            GameObject fruit = Instantiate(fruitPrefab[UnityEngine.Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
            // Add CircleCollider2D to the fruit
            fruit.AddComponent<CircleCollider2D>();
            fruit.AddComponent<Rigidbody2D>().isKinematic = true;  // Corrected the spelling and added isKinematic

            yield return new WaitForSeconds(secondSpawn);
            Destroy(fruit, 3f);
        }
    }
}
