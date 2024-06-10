using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) // 드래그 중인 객체가 있는지 확인
        {
            // 드래그 중인 객체의 RectTransform을 가져옴
            RectTransform draggedObject = eventData.pointerDrag.GetComponent<RectTransform>();

            // 드롭 영역의 중앙 위치 계산
            draggedObject.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}