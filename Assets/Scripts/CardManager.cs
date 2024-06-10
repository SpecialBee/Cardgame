using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // 카드 프리팹
    public RectTransform cardSpawnPoint; // 카드 생성 위치, RectTransform 사용

    // 카드를 생성하는 메소드
    public void SpawnCard()
    {
        GameObject newCard = Instantiate(cardPrefab, cardSpawnPoint.position, Quaternion.identity);
        newCard.transform.SetParent(cardSpawnPoint, false); // 부모를 CardSpawnPoint로 설정하고, local transform을 유지
        RectTransform newCardRect = newCard.GetComponent<RectTransform>();
        newCardRect.anchoredPosition = Vector3.zero; // CardSpawnPoint의 중앙에 위치
        newCardRect.localScale = Vector3.one; // 크기 조정
    }
}
