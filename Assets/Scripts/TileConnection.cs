using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TileConnection
{
    Tile[] linkedTiles = new Tile[2];

    public TileConnection(Tile linkFrom, Tile linkTo)
    {
        linkedTiles[0] = linkFrom;
        linkedTiles[1] = linkTo;

        linkTo.AddTileConnection(this);
    }
}
