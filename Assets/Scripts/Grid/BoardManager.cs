using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // 필드에 깔릴 셀(Tile) 프리팹
    public GameObject tilePrefab;

    // 필드 가로/세로 크기
    public int width = 6;
    public int height = 6;

    // 셀 간의 거리 (1보다 크면 간격 있음)
    public float spacing = 1.1f;

    void Start()
    {
        GenerateGrid(); // 게임 시작 시 자동 실행
    }

    // 6x6 셀을 생성해서 바닥에 깔기
    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                // 셀 하나의 위치 계산 (격자형으로 배치)
                Vector3 position = new Vector3(x * spacing, 0, z * spacing);

                // 프리팹을 위치에 복제하면서 원래 회전값 유지
                GameObject tile = Instantiate(tilePrefab, position, tilePrefab.transform.rotation, this.transform);

                // (선택) 이름으로 좌표를 확인할 수 있게 설정
                tile.name = $"Tile_{x}_{z}";
            }
        }
    }
}
