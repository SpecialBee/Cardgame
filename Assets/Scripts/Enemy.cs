using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;  // 적의 초기 체력
    public GameObject explosionEffect;
    public Element element;

    public void TakeDamage(float amount)
    {
        health -= amount;  // 받은 피해만큼 체력 감소
        if (health <= 0f)
        {
            Die();  // 체력이 0 이하면 사망 처리
        }
    }

    void Die()
    {
        Destroy(gameObject);  // 적 게임 오브젝트 제거
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
    }
}
