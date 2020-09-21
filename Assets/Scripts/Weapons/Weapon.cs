using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] protected GameObject bullet;

    [SerializeField] protected int magSize;
    [SerializeField] protected float energyCostPerBullet;
    [SerializeField] protected int damage;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float bulletSpeed;

    public abstract void Shoot();
    public abstract void Reload();
}
