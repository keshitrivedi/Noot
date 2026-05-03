using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    private float xLimUp;
    private float xLimLow;
    private float zLimUp;
    private float zLimLow;
    public GameObject bacchaPrefab;
    public GameObject mummi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xLimUp = transform.position.x + 20;
        xLimLow = transform.position.x - 20;

        zLimUp = transform.position.z + 20;
        zLimLow = transform.position.z - 20;

        // bacchaPrefab.GetComponent<Baccha>().mummi = mummi;

        StartCoroutine(Spawn(Random.Range(10f, 20f)));
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn(Random.Range(10, 20));
    }

    IEnumerator Spawn(float delaySeconds)
    {
        while (true) {
            yield return new WaitForSeconds(delaySeconds);

            xLimUp = transform.position.x + 20;
            xLimLow = transform.position.x - 20;

            zLimUp = transform.position.z + 20;
            zLimLow = transform.position.z - 20;

            Vector3 randomSpawnPos = new Vector3(Random.Range(xLimLow, xLimUp), 0, Random.Range(zLimLow, zLimUp));

            GameObject spawnedBaccha = Instantiate(bacchaPrefab, randomSpawnPos, Quaternion.identity);
            Baccha spawnedBacchaScript = spawnedBaccha.GetComponent<Baccha>();

            if (spawnedBaccha)
            {
                spawnedBacchaScript.mummi = mummi;
            }

            Debug.Log(randomSpawnPos);
        }
    }
}
