using UnityEngine;
using System.Collections.Generic;

namespace StartFramework.GamePlay.BehaviourTree
{
    public class Node
    {
        public enum Status { SUCCESS, RUNNING, FAILURE }

        public Status status;
        public List<Node> children = new List<Node>();
        public int currentChildren = 0;
        public string name;

        public Node() { }
        public Node(string name)
        {
            this.name = name;
        }

        public void AddChild(Node node)
        {
            children.Add(node);
        }

        public virtual Status Process()
        {
            return children[currentChildren].Process();
        }

        //递归debug树
        public void DebugTree(int level = 0)
        {
            Debug.Log(new string('■', level) + name + "\n");
            level++;
            for (int i = 0; i < children.Count; i++)
            {
                children[i].DebugTree(level);
            }
        }

        //非递归Debug树
        struct NodeLevel { public int Level; public Node node; }
        public void PrintTree()
        {
            string treePrintOut = string.Empty;
            Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
            Node currentNode = this;
            nodeStack.Push(new NodeLevel { Level = 0, node = currentNode });

            while (nodeStack.Count != 0)
            {
                NodeLevel nextNode = nodeStack.Pop();
                treePrintOut += new string('-', nextNode.Level) + nextNode.node.name + "\n";
                for (int i = nextNode.node.children.Count - 1; i >= 0; i--)
                {
                    nodeStack.Push(new NodeLevel() { Level = nextNode.Level + 1, node = nextNode.node.children[i] });
                }
            }

            Debug.Log(treePrintOut);
        }
    }
}