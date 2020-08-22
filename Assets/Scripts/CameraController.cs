using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Transform pathFollower;
    public float zOffset = -30.0f;

    [SerializeField] private float rotationInterpolation = 0.05f;
    [SerializeField] private float movementInterpolation = 0.01f;

    private void Awake()
    {
        
    }
    
    private void LateUpdate()
    {

        transform.localRotation = Quaternion.Lerp(Quaternion.identity, Player.Instance.ship.transform.localRotation, rotationInterpolation);

        Vector3 pos;
        pos.x = Mathf.Clamp(Player.Instance.transform.localPosition.x, -10.0f, 10.0f);
        pos.y = Mathf.Clamp(Player.Instance.transform.localPosition.y, -10.0f, 10.0f);
        pos.z = zOffset;

        Debug.Log(movementInterpolation * Time.deltaTime);

        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, movementInterpolation*Time.deltaTime);
        //transform.localPosition = pos;
    }
}
