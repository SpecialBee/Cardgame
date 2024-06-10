using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject towerPrefab;
    public int width = 10;
    public int height = 10;
    public float cellSize = 1.0f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * cellSize, 0, y * cellSize);
                Instantiate(cellPrefab, position, Quaternion.identity, transform);
            }
        }
    }

    public void PlaceTowerAt(Vector3 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 gridPosition = hit.point;
            int x = Mathf.RoundToInt(gridPosition.x / cellSize);
            int y = Mathf.RoundToInt(gridPosition.z / cellSize);
            Vector3 spawnPosition = new Vector3(x * cellSize + cellSize / 2, 0, y * cellSize + cellSize / 2);
            Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
