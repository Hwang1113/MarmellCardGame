using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class CardDisplay : MonoBehaviour
{
    // 카드 데이터 연결용 변수 (예: Anko.asset)
    public CardData cardData;

    // 카드 위에 표시될 텍스트 오브젝트 (TextMeshPro)
    public TextMeshPro textMesh;

    // 현재 카드가 앞면인지 여부 (초기값: true)
    private bool isFaceUp = true;

    // 게임 시작 시 한 번 실행
    void Start()
    {
        // 데이터와 텍스트가 정상 연결돼 있을 때만
        if (cardData != null && textMesh != null)
        {
            // 다국어 카드 이름을 가져와서 텍스트에 표시
            cardData.cardName.StringChanged += (localizedText) =>
            {
                textMesh.text = localizedText;
            };

            // 초기 상태에 따라 텍스트 표시 여부 갱신
            UpdateCardVisual();
        }
    }

    // 마우스로 오브젝트 클릭했을 때 자동 호출됨
    void OnMouseDown()
    {
        // 앞면/뒷면 상태 전환
        isFaceUp = !isFaceUp;

        // 카드 데이터에도 상태 저장
        cardData.currentState = isFaceUp ? CardState.FaceUp : CardState.FaceDown;

        // 오브젝트 자체 회전 (앞면: 0도 / 뒷면: 180도)
        transform.rotation = Quaternion.Euler(0, isFaceUp ? 0 : 180, 0);

        // 텍스트 표시/숨김 상태 갱신
        UpdateCardVisual();
    }

    // 카드 상태에 따라 시각적 표현을 업데이트
    void UpdateCardVisual()
    {
        if (textMesh != null)
        {
            // 앞면이면 텍스트 보이게, 뒷면이면 숨김
            textMesh.gameObject.SetActive(cardData.currentState == CardState.FaceUp);
        }
    }
}
