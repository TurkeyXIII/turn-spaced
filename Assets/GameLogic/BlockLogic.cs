using Assets.BehaviourFramework;
using Assets.BehaviourInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameLogic
{
    public class BlockLogic : LogicBase<IBlockBehaviour>
    {
        public void CreateTiles()
        {
            Vector2Int size = Behaviour.Size;
        }
    }
}
