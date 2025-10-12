using System.Collections.Generic;
using UnityEngine;

public class Pawns : MonoBehaviour
{
    public Board board;
    public GameObject pawnPrefab;
    private List<GameObject> pawnsList = new();

    void Start()
    {
        for(int x = 1; x < 9; x++)
        {
            Vector3 worldPosition = board.GetWorldPositionByIndex(new Vector2Int(x, 2));

            GameObject pawn = Instantiate(pawnPrefab,worldPosition, Quaternion.identity, transform);

            pawnsList.Add(pawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
