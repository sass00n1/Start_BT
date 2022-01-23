using UnityEngine;

namespace StartFramework.GamePlay.BehaviourTree
{
    /// <summary>
    /// 选择器
    /// 一个接一个的执行子节点
    /// 如果子节点返回：
    /// ● 成功：结束迭代
    /// ● 失败：下一帧执行下一个节点
    /// ● 运行：下一帧再次执行该节点
    /// </summary>
    public class Selector : Node
    {
        public Selector(string name)
        {
            this.name = $"[选择器]{name}";
        }

        public override Status Process()
        {
            Status childStatus = children[currentChildren].Process();
            if (childStatus == Status.RUNNING) return Status.RUNNING;

            if (childStatus == Status.SUCCESS)
            {
                currentChildren = 0;
                return Status.SUCCESS;
            }

            currentChildren++;
            if (currentChildren >= children.Count)
            {
                currentChildren = 0;
                return Status.FAILURE;
            }

            return Status.RUNNING;
        }
    }
}