using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.BehaviourFramework
{
    public abstract class BehaviourBase<L, B> : MonoBehaviour
        where L : LogicBase<B>, new()
        where B: class
    {
        public L Logic { get; private set; }

        void Awake()
        {
            Logic = new L
            {
                Behaviour = this as B,
            };
        }
    }
}
