using System;
using System.Linq;

class Program
{
    class TreeNode
    {
        public int Value;
        public TreeNode? Left;
        public TreeNode? Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    static TreeNode? BuildTree(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return null;

        int maxIndex = Array.IndexOf(arr, arr.Max());
        TreeNode node = new TreeNode(arr[maxIndex]);

        int[] leftArr = arr.Take(maxIndex).OrderByDescending(x => x).ToArray();
        TreeNode? leftNode = null;
        foreach (var val in leftArr)
        {
            if (leftNode == null)
            {
                leftNode = new TreeNode(val);
                node.Left = leftNode;
            }
            else
            {
                leftNode.Left = new TreeNode(val);
                leftNode = leftNode.Left;
            }
        }

        int[] rightArr = arr.Skip(maxIndex + 1).OrderByDescending(x => x).ToArray();
        TreeNode? rightNode = null;
        foreach (var val in rightArr)
        {
            if (rightNode == null)
            {
                rightNode = new TreeNode(val);
                node.Right = rightNode;
            }
            else
            {
                rightNode.Right = new TreeNode(val);
                rightNode = rightNode.Right;
            }
        }

        return node;
    }

    static void PrintTree(TreeNode? node, string indent = "", bool isLeft = true)
    {
        if (node == null)
            return;

        if (indent == "")
            Console.WriteLine("ROOT-- " + node.Value);
        else
            Console.WriteLine(indent + (isLeft ? "L-- " : "R-- ") + node.Value);

        PrintTree(node.Left, indent + (isLeft ? "|   " : "    "), true);
        PrintTree(node.Right, indent + (isLeft ? "|   " : "    "), false);
    }

    static void Main()
    {
        int[] scenario1 = { 3, 2, 1, 6, 0, 5 };
        int[] scenario2 = { 7, 5, 13, 9, 1, 6, 4 };

        Console.WriteLine("Cenario 1:");
        TreeNode? tree1 = BuildTree(scenario1);
        PrintTree(tree1);

        Console.WriteLine("\nCenario 2:");
        TreeNode? tree2 = BuildTree(scenario2);
        PrintTree(tree2);
    }
}
