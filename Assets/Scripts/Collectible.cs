using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // [SerializeField] private Collider collColl;
    // private bool isCollected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Debug.Log("Wao Khaana");
            // isCollected = true;
            gameObject.SetActive(false);
        }
    }

    void transformCollectible()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 2) * 2, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transformCollectible();
    }
}
