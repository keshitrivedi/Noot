using UnityEngine;
using UnityEngine.InputSystem;

public class safeZone : MonoBehaviour
{
    private bool isEnteredSafe;
    private int currCap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        isEnteredSafe = false;
    }
    void Start()
    {
        currCap = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        isEnteredSafe = true;
    }

    void OnTriggerExit(Collider other)
    {
        isEnteredSafe = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if isEntered, and if discard key is pressed,
        //  if safeCap < capacity (3) and count of bachalog is greater than 1
        //      pop baccha from list
        //      change position (and disable following)
        //      increment safeCap int

        // discard is X
        if (isEnteredSafe && Keyboard.current.xKey.wasPressedThisFrame)
        {
            if (currCap < 3 && Glowbawls.bacchaLog.Count > 1)
            {
                Glowbawls.bacchaLog[Glowbawls.bacchaLog.Count - 1].transform.position = this.transform.position;
                Glowbawls.bacchaLog[Glowbawls.bacchaLog.Count - 1].isDiscarded = true;
                Glowbawls.bacchaLog.RemoveAt(Glowbawls.bacchaLog.Count - 1);
                currCap ++;
            }
        }
    }
}
