using UnityEngine;

namespace StartFramework.GamePlay.BehaviourTree
{
    /// <summary>
    /// 序列
    /// 一个接一个的执行子节点，迭代完成之后再从头开始。
    /// 如果子节点返回：
    /// ● 成功：序列在下一帧执行下一个子节点
    /// ● 失败：返回失败(可用于中断树的迭代。例如多于500元钱时静止)
    /// ● 运行：序列在下一帧再次执行该节点
    /// </summary>
    public class Sequence : Node
    {
        public Sequence(string name)
        {
            this.name = $"[序列]{name}";
        }

        public override Status Process()
        {
            Status childStatus = children[currentChildren].Process();

            if (childStatus == Status.RUNNING)
            {
                return Status.RUNNING;
            }
            if (childStatus == Status.FAILURE) return childStatus;

            currentChildren++;
            if (currentChildren >= children.Count)
            {
                currentChildren = 0;
                return Status.SUCCESS;
            }

            return Status.RUNNING;
        }
    }
}