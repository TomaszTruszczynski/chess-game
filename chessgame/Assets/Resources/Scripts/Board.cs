using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform tilesRoot;

    Grid boardGrid;

    void Start()
    {
        boardGrid = GetComponent<Grid>();

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                bool isBlack = (x + y) % 2 == 0;

                Vector3 worldPosition = boardGrid.GetCellCenterWorld(new Vector3Int(x - 4, y - 4, 0));

                GameObject tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity, tilesRoot);
                tile.name = $"Tile_{x}_{y}";

                if (isBlack)
                {
                    if (tile.TryGetComponent(out SpriteRenderer sprite))
                    {
                        sprite.color = Color.black;
                    }
                }
            }
        }
    }

    public Vector3 GetWorldPositionByIndex(Vector2Int boardTilePosition)
    {
        return boardGrid.GetCellCenterWorld(new Vector3Int(boardTilePosition.x - 5, boardTilePosition.y - 5, -1));
    }
}
