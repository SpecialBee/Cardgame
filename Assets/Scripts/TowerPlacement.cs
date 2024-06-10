using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab; // 타워 프리팹
    public LayerMask gridLayer; // 그리드 레이어
    public float gridSize = 1f; // 그리드 크기

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            Vector3Int gridPosition = GetNearestGridPosition(mousePosition);
            if (IsGridPositionValid(gridPosition))
            {
                PlaceTower(gridPosition);
            }
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    Vector3Int GetNearestGridPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x / gridSize);
        int y = Mathf.RoundToInt(position.y / gridSize);
        int z = Mathf.RoundToInt(position.z / gridSize);
        return new Vector3Int(x, y, z);
    }

    bool IsGridPositionValid(Vector3Int position)
    {
        // 그리드 내에 있는지 검사하는 로직을 여기에 추가하세요.
        // 예를 들어, 그리드의 위치가 장애물이 없는 유효한 위치인지 검사할 수 있습니다.
        return true; // 일단은 모든 위치를 유효하다고 가정합니다.
    }

    void PlaceTower(Vector3Int position)
    {
        Vector3 towerPosition = new Vector3(position.x * gridSize, position.y * gridSize, position.z * gridSize);
        Instantiate(towerPrefab, towerPosition, Quaternion.identity);
    }
}
