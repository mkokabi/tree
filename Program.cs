using System;

namespace tree
{
  public class Tree
  {
    public class Node
    {
      public Node(int value)
      {
        this.Value = value;
      }
      public int Value { get; private set; }
      public Node Left { get; set; }
      public Node Right { get; set; }

      public override string ToString()
      {
        return this.Value.ToString();
      }
      public void Display()
      {
        Console.Write(Value + " ");
      }
    }

    public Node Root { get; private set; }

    public void Add(int value)
    {
      if (Root == null)
      {
        this.Root = new Node(value);
        return;
      }

      var cur = Root;
      while (true)
      {
        if (value > cur.Value)
        {
          if (cur.Right != null)
          {
            cur = cur.Right;
            continue;
          }
          cur.Right = new Node(value);
          break;
        }
        else
        {
          if (cur.Left != null)
          {
            cur = cur.Left;
            continue;
          }
          cur.Left = new Node(value);
          break;
        }
      }
    }
    public void TraverseInOrder(Node node)
    {
      if (node == null)
      {
        return;
      }
      TraverseInOrder(node.Left);
      node.Display();
      TraverseInOrder(node.Right);
    }
    public void TraversePreOrder(Node node)
    {
      if (node == null)
      {
        return;
      }
      node.Display();
      TraversePreOrder(node.Left);
      TraversePreOrder(node.Right);
    }
    public void TraversePostOrder(Node node)
    {
      if (node == null)
      {
        return;
      }
      TraversePostOrder(node.Left);
      TraversePostOrder(node.Right);
      node.Display();
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var tree = new Tree();
      tree.Add(50);
      tree.Add(40);
      tree.Add(60);
      tree.Add(65);
      tree.Add(55);

      tree.TraverseInOrder(tree.Root);
      Console.WriteLine();
      tree.TraversePreOrder(tree.Root);
      Console.WriteLine();
      tree.TraversePostOrder(tree.Root);
      Console.WriteLine();
    }
  }
}
