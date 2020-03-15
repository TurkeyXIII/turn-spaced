using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private List<TileConnection> _tileConnections;

    void Awake()
    {
        _tileConnections = new List<TileConnection>();
    }

    public void LinkTile(Tile tile)
    {
        _tileConnections.Add(new TileConnection(this, tile));
    }

    public void AddTileConnection(TileConnection tileConnection)
    {
        _tileConnections.Add(tileConnection);
    }
}
