using System.Collections;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    private float xLimUp;
    private float xLimLow;
    private float zLimUp;
    private float zLimLow;

    public GameObject baccha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xLimUp = transform.position.x + 20;
        xLimLow = transform.position.x - 20;

        zLimUp = transform.position.z + 20;
        zLimLow = transform.position.z - 20;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn(Random.Range(200, 300));
    }

    IEnumerator Spawn(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        Vector3 randomSpawnPos = new Vector3(Random.Range(xLimLow, xLimUp), 0, Random.Range(zLimLow, zLimUp));

        Debug.Log(randomSpawnPos);
    }
}
