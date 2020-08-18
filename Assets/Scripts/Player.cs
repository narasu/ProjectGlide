using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputMaster controls;
    [SerializeField] private float jetSpeed = 5.0f;
    [SerializeField] private float aimSpeed = 5.0f;
    private Vector3 movement;

    private Vector3 aimDirection;

    Quaternion rotation;
    Quaternion prevRotation;

    [SerializeField] private float rotationIntensity = 5.0f;

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
        prevRotation = transform.localRotation;
        rotation = Quaternion.Euler(new Vector3(-aimDirection.y * rotationIntensity, aimDirection.x * rotationIntensity));
        transform.localRotation = Quaternion.Lerp(prevRotation, rotation, 0.1f);
        //movement = Vector3.forward * jetSpeed * Time.deltaTime + aimDirection * aimSpeed * Time.deltaTime;
        movement = Vector3.forward * jetSpeed * Time.deltaTime;
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
