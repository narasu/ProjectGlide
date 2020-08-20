using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using PathCreation;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject ship;
    
    private InputMaster controls;
    [SerializeField] private float jetSpeed = 50.0f;

    private Vector3 aimDirection;
    public bool invertY;

    Quaternion rotation;
    Quaternion prevRotation;

    [SerializeField] private Vector2 turnIntensity = new Vector2(35, 20);
    [SerializeField] private Vector2 turnSpeed = new Vector2(35, 20);
    [SerializeField] private float rollIntensity = 3.0f;
    [Range(0.0f,1.0f)] [SerializeField] private float movementInterpolation = 0.8f;
    [Range(0.0f, 0.1f)] [SerializeField] private float angularInterpolation = 0.01f;

    private void Awake()
    {
        instance = this;

        //input setup 
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
    }

    private void Update()
    {
        prevRotation = ship.transform.localRotation;

        float zRotation = Mathf.Atan2(-aimDirection.x, Mathf.Abs(aimDirection.y)) * rollIntensity;
        rotation = Quaternion.Euler(new Vector3(-aimDirection.y * turnIntensity.y, aimDirection.x * turnIntensity.x, zRotation));
        ship.transform.localRotation = Quaternion.Lerp(prevRotation, rotation, angularInterpolation);

        //Vector3 movement = Vector3.forward * jetSpeed * Time.deltaTime;

        Vector3 movement = aimDirection * turnSpeed * Time.deltaTime;
        Vector3 nextPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + movement, movementInterpolation);

        transform.localPosition = nextPosition;
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
    }

    public float GetSpeed()
    {
        return jetSpeed;
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
