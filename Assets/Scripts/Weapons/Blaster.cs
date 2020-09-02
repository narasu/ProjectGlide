using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    public override void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = firePoint.position;
        b.transform.rotation = firePoint.rotation;
        b.GetComponent<Rigidbody>().velocity = firePoint.forward * (Player.Instance.GetSpeed() + bulletSpeed);
    }

    public override void Reload()
    {
        
    }
}
