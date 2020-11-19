using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    //public GameObject baseObject;
    public GameObject barrelPivotObject;
    public Transform firePoint;
    public GameObject bullet;
    public float fireRate = 1.0f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireRate);
            GameObject b = Instantiate(bullet);
            b.transform.position = firePoint.position;
            //b.transform.rotation = firePoint.localRotation;
            b.GetComponent<Rigidbody>().velocity = firePoint.up * 400.0f;
            //Debug.Log($"Bullet Velocity={b.GetComponent<Rigidbody>().velocity}");
        }
    }

    private void Update()
    {
        RotateToPlayer();
    }

    private void RotateToPlayer()
    {
        Vector3 baseDirection = (Player.Instance.transform.position - transform.position).normalized;
        Quaternion baseRotation = Quaternion.LookRotation(baseDirection);
        baseRotation.x = 0;
        baseRotation.z = 0;
        transform.rotation = baseRotation;

        Vector3 aimDirection = (Player.Instance.transform.position - barrelPivotObject.transform.position).normalized;
        Quaternion barrelRotation = Quaternion.LookRotation(aimDirection,barrelPivotObject.transform.up);
        barrelRotation.y = 0;
        barrelRotation.z = 0;
        barrelPivotObject.transform.localRotation = barrelRotation;
    }


    protected override void Die()
    {
        // instantiate explosion

        base.Die();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        // some sort of hit fx here
    }
}
