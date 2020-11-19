using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int health;
    //[SerializeField] protected int scoreReward;

    protected virtual void Die() 
    {
        Destroy(gameObject);
        //GameManager.Instance.score += scoreReward;
    }
    public virtual void TakeDamage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
            Die();
    }
}
