using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"colliding {collision.collider}");
        collision.collider.GetComponent<IDamageable>()?.TakeDamage(1);
        Destroy(gameObject);
    }
}
