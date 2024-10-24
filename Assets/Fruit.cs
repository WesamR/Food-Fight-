using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefab;
    [SerializeField] float secondSpawn = 5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    public int numberOfFood;
    public bool infinite = false;

    int counter=0;
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()
    {
        while (counter< numberOfFood)
        {
            var wanted = UnityEngine.Random.Range(minTras, 5);
            var position = new Vector2(wanted, transform.position.y);
            GameObject fruit = Instantiate(fruitPrefab[UnityEngine.Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            //Destroy(fruit, 3f);
           
            if(!infinite) counter++;
        }
    }
}
