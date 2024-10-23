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
            var position = new Vector3(wanted, transform.position.y, transform.position.z);
            GameObject gameObject = Instantiate(fruitPrefab[UnityEngine.Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 3f);
        }
    }
}
