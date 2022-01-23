using UnityEngine;
using System;

namespace StartFramework.GamePlay.BehaviourTree
{
    /// <summary>
    /// If节点
    /// 如果条件为true，则依次执行子节点，具有阻塞效果
    /// </summary>
    public class If : Node
    {
        private Func<bool> processMethod;
        private bool tested; //验证flag

        public If(string name, Func<bool> processMethod)
        {
            this.name = $"[If]{name}";
            this.processMethod = processMethod;
        }

        public override Status Process()
        {
            //意图：只要进入if节点，就进行验证，直到所有子节点迭代完毕后取消验证。
            //不然的话，在下一帧，if的判断如果为false，则直接返回success，执行下一个节点，这个if就不会有阻塞效果。
            if (tested == false)
            {
                tested = processMethod();
            }

            if (tested == true)
            {
                Status childStatus = children[currentChildren].Process();

                if (childStatus == Status.RUNNING)
                {
                    return Status.RUNNING;
                }
                if (childStatus == Status.FAILURE)
                {
                    return childStatus;
                }

                currentChildren++;

                if (currentChildren >= children.Count)
                {
                    currentChildren = 0;
                    tested = false;
                    return Status.SUCCESS;
                }

                return Status.RUNNING;
            }
            else
            {
                return Status.SUCCESS;
            }
        }
    }
}