using System.Collections;
using UnityEngine;

public class Adoption : MonoBehaviour
{
    public bool isAdopted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(destroyBaccha(15f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAdopted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyBaccha(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        if (!isAdopted)
        {
            Destroy(gameObject);
        }
    }
}
