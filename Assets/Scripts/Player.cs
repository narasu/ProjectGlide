using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputMaster controls;
    [SerializeField] private float jetSpeed = 50.0f;
    [SerializeField] private float aimSpeed = 5.0f;

    private Vector3 aimDirection;
    public bool invertY;

    Quaternion rotation;
    Quaternion prevRotation;

    [SerializeField] private float turnIntensity = 35.0f;
    [SerializeField] private float rollIntensity = 3.0f;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Airship.Shoot.performed += ctx => Shoot();

        if (!invertY)
        {
            controls.Airship.Aim.performed += ctx => aimDirection = ctx.ReadValue<Vector2>();
        }
        else
        {
            controls.Airship.Aim.performed += ctx => aimDirection = new Vector3(ctx.ReadValue<Vector2>().x, -ctx.ReadValue<Vector2>().y);
        }

        
        controls.Airship.Aim.canceled += ctx => aimDirection = Vector2.zero;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Debug.Log(aimDirection);
        
        prevRotation = transform.localRotation;

        float zRotation = Mathf.Atan2(-aimDirection.x, Mathf.Abs(aimDirection.y)) * rollIntensity;
        
        //float zRotation = Vector2.SignedAngle(Vector2.zero, aimDirection) * rollIntensity;


        rotation = Quaternion.Euler(new Vector3(-aimDirection.y * turnIntensity, aimDirection.x * turnIntensity, zRotation));
        transform.localRotation = Quaternion.Lerp(prevRotation, rotation, 0.1f);

        Vector3 movement = Vector3.forward * jetSpeed * Time.deltaTime;
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
