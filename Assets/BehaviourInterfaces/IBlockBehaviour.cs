using Assets.GameLogic;
using UnityEngine;

namespace Assets.BehaviourInterfaces
{
    public interface IBlockBehaviour
    {
        Vector2Int Size { get; }

        TileLogic CreateTile(Vector3 localPosition);
    }
}
