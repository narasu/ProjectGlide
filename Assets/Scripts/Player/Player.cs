using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using PathCreation;
using UnityEngine.InputSystem;
using System;

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

    public List<GameObject> weapons;
    private int selectedWeapon;


    private InputMaster controls;
    [SerializeField] private float jetSpeed = 50.0f;

    private Vector3 aimDirection;
    public bool invertY;
    private int InvertYValue
    {
        get
        {
            if (invertY)
                return -1;
            else
                return 1;
        }
    }

    public Vector2 minPos = new Vector2(-38, -22);
    public Vector2 maxPos = new Vector2(38, 24);

    Quaternion rotation;
    Quaternion prevRotation;

    [SerializeField] private Vector2 turnIntensity = new Vector2(35, 20);
    [SerializeField] private Vector2 movementSpeed = new Vector2(35, 20);
    [SerializeField] private float rollIntensity = 3.0f;
    [Range(0.0f, 1000.0f)] [SerializeField] private float movementInterpolation = 5f;
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
        Vector3 nextPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + movement, movementInterpolation * Time.deltaTime);

        nextPosition.x = Mathf.Clamp(nextPosition.x, minPos.x, maxPos.x);
        nextPosition.y = Mathf.Clamp(nextPosition.y, minPos.y, maxPos.y);

        transform.localPosition = nextPosition;
    }

    private void Shoot()
    {
        //weapons[selectedWeapon].GetComponent<Weapon>()?.Shoot();
        foreach (Weapon w in GetComponentsInChildren<Weapon>())
        {
            if (w.isActiveAndEnabled)
            {
                w.Shoot();
            }
        }
        //Debug.Log($"bullet is traveling at {b.GetComponent<Rigidbody>().velocity} speed");
    }

    public float GetSpeed() => jetSpeed;

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void InitializeInput()
    {
        //input setup 
        controls = new InputMaster();
        controls.Airship.Shoot.performed += ctx => Shoot();
        controls.Airship.Aim.performed += ctx => aimDirection = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y*InvertYValue);
        controls.Airship.Aim.canceled += ctx => aimDirection = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        if (transform.parent!=null)
        {
            Vector3 bottomLeft = transform.parent.TransformPoint(minPos);
            Vector3 topLeft = transform.parent.TransformPoint(new Vector3(minPos.x, maxPos.y));
            Vector3 topRight = transform.parent.TransformPoint(maxPos);
            Vector3 bottomRight = transform.parent.TransformPoint(new Vector3(maxPos.x, minPos.y));

            Gizmos.DrawLine(bottomLeft, topLeft);
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomLeft, bottomRight);
        }
    }
}
