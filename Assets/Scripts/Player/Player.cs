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

    private PlayerFSM fsm;

    public GameObject ship;
    public Transform firePoint;
    public GameObject bullet;

    private InputMaster controls;
    [SerializeField] private float jetSpeed = 50.0f;

    private Vector3 aimDirection;
    public bool invertY;
    
    public float xMin = -32.0f;
    public float xMax = 32.0f;
    public float yMin = -18.0f;
    public float yMax = 18.0f;

    Quaternion rotation;
    Quaternion prevRotation;

    [SerializeField] private Vector2 turnIntensity = new Vector2(35, 20);
    [SerializeField] private Vector2 movementSpeed = new Vector2(35, 20);
    [SerializeField] private float rollIntensity = 3.0f;
    [Range(0.0f, 50.0f)] [SerializeField] private float movementInterpolation = 5f;
    [Range(0.0f, 10.0f)] [SerializeField] private float angularInterpolation = 5f;

    private void Awake()
    {
        instance = this;

        fsm = new PlayerFSM();
        fsm.Initialize(this);

        fsm.AddState(PlayerStateType.Normal, new NormalState());

        InitializeInput();
    }

    private void Start()
    {
        fsm.GotoState(PlayerStateType.Normal);
    }

    private void Update()
    {
        fsm.UpdateState();
    }

    public void HandleRotation()
    {
        prevRotation = ship.transform.localRotation;

        float zRotation = Mathf.Atan2(-aimDirection.x, Mathf.Abs(aimDirection.y)) * rollIntensity;
        rotation = Quaternion.Euler(new Vector3(-aimDirection.y * turnIntensity.y, aimDirection.x * turnIntensity.x, zRotation));
        ship.transform.localRotation = Quaternion.Lerp(prevRotation, rotation, angularInterpolation * Time.deltaTime);
    }

    public void Move()
    {
        Vector3 movement = aimDirection * movementSpeed * Time.deltaTime;
        Vector3 nextPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + movement, movementInterpolation);

        nextPosition.x = Mathf.Clamp(nextPosition.x, xMin, xMax);
        nextPosition.y = Mathf.Clamp(nextPosition.y, yMin, yMax);

        transform.localPosition = nextPosition;
    }

    private void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = firePoint.position;
        b.transform.rotation = firePoint.rotation;
        b.GetComponent<Rigidbody>().velocity = firePoint.forward * (jetSpeed + 150.0f);
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
    private void InitializeInput()
    {
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
}
