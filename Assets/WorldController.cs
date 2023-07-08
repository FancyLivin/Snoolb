using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldController : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private new Camera camera;

    private Grid tilemapGrid;

    private void Start()
    {
        tilemapGrid = tilemap.layoutGrid;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var tile = tilemap.GetTile(mouseToCellPosition());
        }
    }

    public Vector3Int mouseToCellPosition()
    {
        var mousePos = Input.mousePosition;
        var worldPos = camera.ScreenToWorldPoint(mousePos);
        return tilemapGrid.WorldToCell(worldPos);
    }
}
