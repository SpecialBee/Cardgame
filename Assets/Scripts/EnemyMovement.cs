using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private float speed;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            // 타겟 지점으로 이동
            Vector3 dir = target.position - transform.position;
            transform.position += dir.normalized * speed * Time.deltaTime;

            // 목표에 도달했는지 확인
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                ReachedTarget();
            }
        }
    }

    void ReachedTarget()
    {
        // 목표에 도달하면 수행할 동작
        Debug.Log("Target reached!");

        // 적 객체를 파괴
        Destroy(gameObject);
    }
}
