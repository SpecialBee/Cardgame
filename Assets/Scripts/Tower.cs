using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 총알 발사 위치
    public float bulletSpeed = 10f; // 총알 속도
    public float attackRange = 5f; // 공격 범위
    public float attackInterval = 1f; // 공격 간격
    public float damageAmount = 20f; // 총알의 공격력

    private float lastAttackTime; // 마지막 공격 시간

    void Update()
    {
        // 공격 간격에 따라 적을 타겟팅하고 공격
        if (Time.time - lastAttackTime >= attackInterval)
        {
            AcquireAndAttackTarget();
        }
    }

    void AcquireAndAttackTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        Transform closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Vector3 directionToTarget = collider.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestTarget = collider.transform;
                }
            }
        }

        if (closestTarget != null)
        {
            Shoot(closestTarget);
            lastAttackTime = Time.time;
        }
    }

    void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.Seek(target, bulletSpeed, damageAmount);  // 타겟, 속도, 공격력 전달
        }
    }
}
