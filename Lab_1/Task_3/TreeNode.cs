using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Task_3
{
    public class TreeNode
    {
        public string Value { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        { 
            Children.Add(child);
        }

        public void PrintTree(string indent = "", bool isLast = true)
        {
            string fork = isLast ? "└──" : "├──";
            Console.WriteLine(indent + fork + Value);

            string newIndent = indent + (isLast ? "   " : "│  ");

            for (int i = 0; i < Children.Count; i++)
            {
                bool isLastChild = (i == Children.Count - 1);
                Children[i].PrintTree(newIndent, isLastChild);
            }
        }
    }
}
