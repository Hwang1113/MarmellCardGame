using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class CardDisplay : MonoBehaviour
{
    // ī�� ������ ����� ���� (��: Anko.asset)
    public CardData cardData;

    // ī�� ���� ǥ�õ� �ؽ�Ʈ ������Ʈ (TextMeshPro)
    public TextMeshPro textMesh;

    // ���� ī�尡 �ո����� ���� (�ʱⰪ: true)
    private bool isFaceUp = true;

    // ���� ���� �� �� �� ����
    void Start()
    {
        // �����Ϳ� �ؽ�Ʈ�� ���� ����� ���� ����
        if (cardData != null && textMesh != null)
        {
            // �ٱ��� ī�� �̸��� �����ͼ� �ؽ�Ʈ�� ǥ��
            cardData.cardName.StringChanged += (localizedText) =>
            {
                textMesh.text = localizedText;
            };

            // �ʱ� ���¿� ���� �ؽ�Ʈ ǥ�� ���� ����
            UpdateCardVisual();
        }
    }

    // ���콺�� ������Ʈ Ŭ������ �� �ڵ� ȣ���
    void OnMouseDown()
    {
        // �ո�/�޸� ���� ��ȯ
        isFaceUp = !isFaceUp;

        // ī�� �����Ϳ��� ���� ����
        cardData.currentState = isFaceUp ? CardState.FaceUp : CardState.FaceDown;

        // ������Ʈ ��ü ȸ�� (�ո�: 0�� / �޸�: 180��)
        transform.rotation = Quaternion.Euler(0, isFaceUp ? 0 : 180, 0);

        // �ؽ�Ʈ ǥ��/���� ���� ����
        UpdateCardVisual();
    }

    // ī�� ���¿� ���� �ð��� ǥ���� ������Ʈ
    void UpdateCardVisual()
    {
        if (textMesh != null)
        {
            // �ո��̸� �ؽ�Ʈ ���̰�, �޸��̸� ����
            textMesh.gameObject.SetActive(cardData.currentState == CardState.FaceUp);
        }
    }
}
