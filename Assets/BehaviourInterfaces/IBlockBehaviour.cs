using Assets.GameLogic;
using UnityEngine;

namespace Assets.BehaviourInterfaces
{
    public interface IBlockBehaviour
    {
        TileLogic CreateTile(Vector3 localPosition);
    }
}
