using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // ī�޶� ȸ�� �ӵ�
    public float lookSpeed = 120.0f;

    // ���콺 ������ ��ȭ���� ������ ����
    [SerializeField]
    private Vector2 lookDelta = Vector2.zero;

    public Player controls;

    private void Awake()
    {
        controls = new Player();
        Debug.Log(controls);
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.PlayerActionMap.Look.performed += OnLook;
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.PlayerActionMap.Look.performed -= OnLook;
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookDelta = context.ReadValue<Vector2>();
        //lookDelta *= lookSpeed * Time.deltaTime;
        //float rotateSpeed = lookDelta.x * lookSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.up, rotateSpeed);
    }




    private void Update()
    {
        // ���콺 ������ ��ȭ���� ���� ��쿡�� ī�޶� ȸ����ŵ�ϴ�.
        if (lookDelta != Vector2.zero)
        {
            transform.Rotate(Vector3.up, lookDelta.x * Time.deltaTime * lookSpeed);
        }
    }
}
