using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // �ʵ忡 �� ��(Tile) ������
    public GameObject tilePrefab;

    // �ʵ� ����/���� ũ��
    public int width = 6;
    public int height = 6;

    // �� ���� �Ÿ� (1���� ũ�� ���� ����)
    public float spacing = 1.1f;

    void Start()
    {
        GenerateGrid(); // ���� ���� �� �ڵ� ����
    }

    // 6x6 ���� �����ؼ� �ٴڿ� ���
    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                // �� �ϳ��� ��ġ ��� (���������� ��ġ)
                Vector3 position = new Vector3(x * spacing, 0, z * spacing);

                // �������� ��ġ�� �����ϸ鼭 ���� ȸ���� ����
                GameObject tile = Instantiate(tilePrefab, position, tilePrefab.transform.rotation, this.transform);

                // (����) �̸����� ��ǥ�� Ȯ���� �� �ְ� ����
                tile.name = $"Tile_{x}_{z}";
            }
        }
    }
}
