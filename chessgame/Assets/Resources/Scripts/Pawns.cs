using System.Collections.Generic;
using UnityEngine;

public class Pawns : MonoBehaviour
{
    public Board board;
    public GameObject pawnPrefab;
    private List<GameObject> pawnsList = new();

    void Start()
    {
        for (int x = 1; x < 9; x++)
        {
            GameObject goWhite = GeneratePawn(new Vector2Int(x, 2), false);
            GameObject goBlack = GeneratePawn(new Vector2Int(x, 7), true);

            pawnsList.Add(goWhite);
            pawnsList.Add(goBlack);
        }
    }

    private GameObject GeneratePawn(Vector2Int index, bool isBlack)
    {
        Vector3 worldPosition = board.GetWorldPositionByIndex(index);

        GameObject go = Instantiate(pawnPrefab, worldPosition, Quaternion.identity, transform);

        if (isBlack)
        {
            Pawn pawn = go.GetComponent<Pawn>();
            pawn.isBlack = true;

            SpriteRenderer sprite = go.GetComponent<SpriteRenderer>();
            sprite.color = Color.blueViolet;
        }

        return go;
    }


    public void ResetGame()
    {
        foreach (GameObject pawn in pawnsList)
        {
            Destroy(pawn);
        }
        pawnsList.Clear();
    }
}

