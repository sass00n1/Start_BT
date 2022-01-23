using UnityEngine;
using System.Collections.Generic;

namespace StartFramework.GamePlay.BehaviourTree
{
    //行为树对比FSM的优势：
    //1.行为树是视觉可读的。FSM会有大量的状态转换，形成意大利面状态机。
    //2.行为树易于修改，对设计师有利。
    //3.节点功能强大，例如并行节点。

    /// <summary>
    /// 树的主干
    /// </summary>
    public class BehaviourTree : Node
    {
        public BehaviourTree()
        {
            this.name = "<color=red>===行为树调试===</color>";
        }

        public BehaviourTree(string name)
        {
            this.name = name;
        }

        public override Status Process()
        {
            return children[currentChildren].Process();
        }
    }
}