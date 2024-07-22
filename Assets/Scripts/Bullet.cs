using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speed;  // 총알의 속도
    private float damage;  // 총알의 공격력
    public float baseDamage;
    public Element element;

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            float damageMultiplier = ElementalDamage.GetDamageMultiplier(element, enemy.element);
            float finalDamage = baseDamage * damageMultiplier;
            enemy.TakeDamage(finalDamage);
            Destroy(gameObject);
        }
    }

    public void Seek(Transform _target, float _speed, float _damage)
    {
        target = _target;
        speed = _speed;
        damage = _damage;
    }

    public GameObject explosionEffect; // 폭발 효과 프리팹

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);  // 타겟이 없으면 총알 파괴
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);  // 타겟에 도달하면 총알 파괴
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
    }
}
