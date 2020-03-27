using BehaviourInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class BlockLogic
    {
        private readonly IBlockBehaviour _blockBehaviour;

        public BlockLogic(IBlockBehaviour blockBehaviour)
        {
            _blockBehaviour = blockBehaviour;
        }
    }
}
