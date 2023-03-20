using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCharacterController : MonoBehaviour
{
    public static MyCharacterController Instance = null;

    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float gravity = 20f;

    private Vector2 moveInput;
    private bool jumpInput;

    private Vector3 moveDirection;
    private CharacterController controller;

    private InputAction leftMouseClick;

    public bool IsArrived { set; get; }

    void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
        controller = GetComponent<CharacterController>();

        leftMouseClick = new InputAction(binding: "<Mouse>/leftButton");
        leftMouseClick.performed += ctx => LeftMouseClicked();
        leftMouseClick.Enable();
    }

    private void Start()
    {
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpInput = true;
        }
    }

    void OnNextSub(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("OnNextSub");
        }
    }

    private void LeftMouseClicked()
    {
        try
        {
            if (gameObject.GetComponent<PlayerInput>().actions.enabled)
            {
                Debug.Log("LeftMouseClicked");
                try
                {
                    SelectShopSubs.Instance.NextPage();
                }
                catch { }
            }
        }
        catch { }
    }

    // ÄÁÆ®·Ñ On / Off
    public void HoldControl(bool signal)
    {
        if (signal) // OFF
        {
            gameObject.GetComponent<PlayerInput>().actions.Disable();
        }
        else // ON
        {
            gameObject.GetComponent<PlayerInput>().actions.Enable();
        }
    }

    public void MoveToPosition(Transform target)
    {
        if (!IsArrived)
        {
            Vector3 dir = target.position - transform.position;
            dir.y = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0f);

            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    void Update()
    {
        if (gameObject.GetComponent<PlayerInput>().actions.enabled)
        {
            moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            //Jump
            if (jumpInput && controller.isGrounded)
            {
                moveDirection.y = jumpForce;
                jumpInput = false;
            }

            moveDirection.y -= gravity * Time.deltaTime;

            //controller.Move(moveDirection * Time.deltaTime);
        }

        if(IsArrived)
        {
            IsArrived = false;
            HoldControl(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arrived")
        {
            Debug.Log("Arrived");
            this.IsArrived = true;

            SelectShopSubs.Instance.Id++;
        }
    }
}
