using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 적 프리팹
    public Transform spawnPoint; // 생성할 위치
    public Transform targetPoint; // 목표 위치
    public float moveSpeed = 5f; // 이동 속도
    public float spawnInterval = 2f; // 소환 간격

    void Start()
    {
        // 일정 간격으로 SpawnEnemy 메소드를 호출
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // 적 생성
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // 적의 이동 스크립트를 가져옴
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            // 목표 지점 설정
            enemyMovement.SetTarget(targetPoint);
            // 이동 속도 설정
            enemyMovement.SetSpeed(moveSpeed);
        }
        else
        {
            Debug.LogError("Enemy Movement script not found on the enemy prefab!");
        }
    }
}
