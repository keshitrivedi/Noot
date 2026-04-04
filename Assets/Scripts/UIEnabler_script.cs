using System.Collections;
using UnityEngine;


public class UIEnabler_script : MonoBehaviour
{
    [SerializeField] private GameObject DialogUI;
    [SerializeField] private Yellow_movement_game gameMov;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogUI.SetActive(false);
    }

    IEnumerator holdUI(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        DialogUI.SetActive(false);
        gameMov.hasCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMov.hasCollected)
        {
            Debug.Log("E ka hove");
            DialogUI.SetActive(true);
            StartCoroutine(holdUI(2f));
        }
    }
}
