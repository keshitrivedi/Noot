using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

// This is the script for the start menu, my ass cannot plan shit beforehand
public class Yellow_movement : MonoBehaviour
{
    private Animator yellow_animator;
    Yellow_movement_game gameMovementScript;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject backCamera;

    private Vector2 lastMousePosition;

    private void OnEnable()
    {
        mainCamera.SetActive(true);
        backCamera.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Sab Khairiyat");
        yellow_animator = GetComponent<Animator>();

        // if (yellow_animator)
        // {
        //     yellow_animator.SetTrigger("TrMenu");
        // }

        // disable other script:
        gameMovementScript = GetComponent<Yellow_movement_game>();
        gameMovementScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 mouseSpeed = (mousePosition - lastMousePosition)/Time.deltaTime;
        lastMousePosition = mousePosition;

        Debug.Log(mouseSpeed.x);
        Debug.Log(mousePosition);

        if (yellow_animator != null)
        {
            // start screen anims
            if (mouseSpeed.x > 50000f)
            {
                yellow_animator.SetTrigger("TrHello");
                Debug.Log("Hello");
            }

            // yellow_animator.SetTrigger("TrIdle");
        }

        // exit the start screen when direction keys
        if (Keyboard.current.wKey.isPressed
            || Keyboard.current.aKey.isPressed
            || Keyboard.current.sKey.isPressed
            || Keyboard.current.dKey.isPressed
        )
        {
            gameMovementScript.enabled = true;
            this.enabled = false;
        }
    }
}
