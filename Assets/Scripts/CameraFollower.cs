using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform yellow_transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float xOff;
    [SerializeField] private float yOff;
    [SerializeField] private float zOff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(yellow_transform.position.x + xOff, yOff, yellow_transform.position.z + zOff);
    }
}
