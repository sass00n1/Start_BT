using UnityEngine;
using System;

namespace StartFramework.GamePlay.BehaviourTree
{
    /// <summary>
    /// 叶子
    /// 执行方法
    /// </summary>
    public class Leaf : Node
    {
        private Func<Status> processMethod;

        public Leaf() { }
        public Leaf(string name, Func<Status> processMethod)
        {
            this.name = $"[叶子]{name}";
            this.processMethod = processMethod;
        }

        public override Status Process()
        {
            if (processMethod != null)
            {
                return processMethod();
            }
            else
            {
                return Status.FAILURE;
            }
        }
    }
}