using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.GameLogic;
using Assets.BehaviourInterfaces;
using Assets.BehaviourFramework;

public class Block : BehaviourBase<BlockLogic, IBlockBehaviour>, IBlockBehaviour
{
    public GameObject BlockShadow;
    public GameObject TileEmpty;
    public GameObject WallSection;
    public Vector2Int Size;

    private List<Doorway> _doorways;
    private TileLogic[,] _tiles;

    public void Awake()
    {
        if (Size.x < 1 || Size.y < 1)
        {
            Destroy(gameObject);
            return;
        }

        CreateTiles();

        //_doorways = GetComponentsInChildren<Doorway>().ToList();
    }

    private void CreateTiles()
    {
        _tiles = new TileLogic[Size.x, Size.y];

        Vector3 bottomLeftCorner = new Vector3(-(float)Size.x / 2, -(float)Size.y / 2);

        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                var tile = CreateTile(bottomLeftCorner + new Vector3(i, j));

                _tiles[i,j] = tile;
            }
        }
    }

    public TileLogic CreateTile(Vector3 localPosition)
    {
        GameObject tile = Instantiate(TileEmpty, transform);
        tile.transform.localPosition = localPosition;

        return tile.GetComponent<Tile>().Logic;
    }

    public List<Vector3> GetViableRoomPositions()
    {
        var viableRoomPositions = new List<Vector3>();
        foreach (var doorway in _doorways)
        {
            var doorwayPositionFromBlock = doorway.transform.localPosition;
            var viableRoomPosition = transform.position + (2 * doorwayPositionFromBlock);

            viableRoomPositions.Add(viableRoomPosition);
        }

        List<object> list = new List<object>();
        
        return viableRoomPositions;
    }
}
