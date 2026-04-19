using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.RenderGraphModule;

public class Yellow_movement_game : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions _input;
    Yellow_movement startScreenMovement;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject backCamera;


    private Animator yellow_animator;
    private Transform yellow_transform;
    private Rigidbody rb;


    [SerializeField] private float _walkSpeed = 15.0f;
    [SerializeField] private float _runSpeed = 20f;
    private float _speed;
    private float jumpHeight = 15f;


    public bool hasCollected = false;


    private Vector3 horizontalInput;
    private Vector3 verticalInput;
    private Vector2 _direction;
    private Vector3 jumpVelocity;
    private void OnEnable()
    {
        _input = new InputSystem_Actions();
        _input.Player.SetCallbacks(this);
        _input.Player.Enable();

        startScreenMovement = GetComponent<Yellow_movement>();

        backCamera.SetActive(true);
        mainCamera.SetActive(false);
        yellow_animator = GetComponent<Animator>();
        yellow_transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        jumpVelocity = new Vector3(0f, jumpHeight, 0f);

        _speed = _walkSpeed;
    }

    IEnumerator Delay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        rb.linearVelocity += jumpVelocity;

        Vector3 vel = rb.linearVelocity;
        vel.y += Physics.gravity.y;
        rb.linearVelocity = vel;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        hasCollected = true;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        if (!context.performed) return;
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        if (!context.performed) return;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        if (!context.performed) return;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        if (!context.performed) return;
        yellow_animator.speed = 1;
        yellow_animator.SetTrigger("TrJump");
        // StartCoroutine(Delay(0.1f));
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        if (!context.performed) return;
    }

    float r; // for smooth rotation idk
    float rg;
    public void OnMove(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        // yellow_animator.speed = 1;
        _direction = context.ReadValue<Vector2>();

        bool isMoving = _direction.sqrMagnitude > 0.01f;
        yellow_animator.SetBool("IsWalking", isMoving);
        // yellow_animator.SetTrigger("TrWalk");

        Debug.Log(_direction);
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        if (!context.performed) return;
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        if (!context.performed) return;
    }

    public bool isSprinting;
    public void OnSprint(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
        // yellow_animator.speed = 2;
        // _speed = 20f;

        if (context.performed)
        {
            _speed = _runSpeed;
            yellow_animator.speed = 1.5f;
            isSprinting = true;
        } else if (context.canceled)
        {
            _speed = _walkSpeed;
            yellow_animator.speed = 1f;
            isSprinting = false;
        }
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        Debug.Log("escape key");
        startScreenMovement.enabled = true;
        this.enabled = false;
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Sab Khairiyat");

        // if (yellow_animator)
        // {
        //     yellow_animator.SetTrigger("TrGame");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(_direction.x, 0f, _direction.y);
        transform.Translate(move * _speed * Time.deltaTime, Space.World);

        if (_direction.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
            float grad = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref r, 0.1f);
            yellow_transform.rotation = Quaternion.Euler(0f, grad, 0f);
        } 
        // else
        // {
        //     float grad_restore = Mathf.SmoothDampAngle(transform.eulerAngles.y, 0f, ref rg, 0.2f);
        //     yellow_transform.rotation = Quaternion.Euler(0f, grad_restore, 0f);
        // }

        // if (Keyboard.current.escapeKey.isPressed)
        // {
        //     Debug.Log("escape key");
        //     startScreenMovement.enabled = true;
        //     this.enabled = false;
        // }
    }
}
