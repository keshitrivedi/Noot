using UnityEngine;

public class Adoption : MonoBehaviour
{
    public bool isAdopted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
