using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject towerPrefab; // 타워 프리팹
    private RectTransform rectTransform;
    private CardManager cardManager;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        cardManager = FindObjectOfType<CardManager>(); // 카드 매니저 찾기
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 로직
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GridManager gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            gridManager.PlaceTowerAt(eventData.position);
            Destroy(gameObject); // 드래그한 카드 삭제
            cardManager.SpawnCard(); // 새 카드 생성
        }
    }
}
