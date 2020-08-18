using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputMaster controls;
    [SerializeField] private float speed = 5.0f;
    private Vector3 movement;
    private Vector3 aimDirection;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Airship.Shoot.performed += ctx => Shoot();

        controls.Airship.Aim.performed += ctx => aimDirection = ctx.ReadValue<Vector2>();
        controls.Airship.Aim.canceled += ctx => aimDirection = Vector2.zero;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Debug.Log(aimDirection);
        movement = Vector3.forward * speed * Time.deltaTime + aimDirection;
        transform.Translate(movement);
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
