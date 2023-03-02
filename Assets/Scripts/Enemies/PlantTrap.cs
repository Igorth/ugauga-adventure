using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBullets;
    private float cooldownTimer;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        cooldownTimer = 0;

        fireBullets[FireBullet()].transform.position = firePoint.position;
        fireBullets[FireBullet()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FireBullet()
    {
        for (int i = 0; i < fireBullets.Length; i++)
        {
            if (!fireBullets[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
}
