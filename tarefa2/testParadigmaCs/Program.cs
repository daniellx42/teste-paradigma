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
        int[] rightArr = arr.Skip(maxIndex + 1).OrderByDescending(x => x).ToArray();

        node.Left = BuildTree(leftArr);
        node.Right = BuildTree(rightArr);

        return node;
    }

    static void PrintTree(TreeNode? node, string indent = "", bool isLeft = true)
    {
        if (node == null)
            return;

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
