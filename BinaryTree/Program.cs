using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        public static TreeNode root;
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(6);
            TreeNode b = new TreeNode(3);
            TreeNode c = new TreeNode(9);

          //  TreeNode root = a;
          //  a.Left = b;
          //  a.Right = c;
            
            int[] listElements = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            root = Add(listElements, 0, listElements.Length - 1);

            Insert_Iterative(5);
            //   Insert_Recursive(5, root);

            //  PrintTree(root, 0, true);

            TreeNode found = Find(999);
            if (found == null)
                Console.WriteLine("Value not found");
            else
                Console.WriteLine("Value {0} found", found.Value);

            DepthFirstTraversal();
            BreadthFirstTraversal();
            Console.Read();
            
        }

        public static void DepthFirstTraversal()
        {
            Stack<TreeNode> s = new Stack<TreeNode>();
            string output = "";

            s.Push(root);
            while (s.Count != 0)
            {
                //pop the top node
                TreeNode current = s.Pop();

                //process it (print the node's value)
                output += current.Value + ", ";

                //push its children.
                if (current.Right != null)
                    s.Push(current.Right);
                if (current.Left != null)
                    s.Push(current.Left);
            }
            Console.WriteLine("Depth First Traversal:");
            Console.WriteLine(output);

        }

        public static void BreadthFirstTraversal()
        {
            Queue<TreeNode> s = new Queue<TreeNode>();
            string output = "";

            s.Enqueue(root);
            while (s.Count != 0)
            {
                //pop the top node
                TreeNode current = s.Dequeue();

                //process it (print the node's value)
                output += current.Value + ", ";

                //push its children.
                if (current.Left != null)
                    s.Enqueue(current.Left);
                if (current.Right != null)
                    s.Enqueue(current.Right);
                
            }
            Console.WriteLine("Breadth First Traversal:");
            Console.WriteLine(output);

        }

        public static TreeNode Find(int valToFind)
        {
            TreeNode current = root;
            while (current != null)
            {
                //look at current value
                //if equal return this node.
                //if valToFind is smaller than current, move left
                //else if valToFind is greater, move right
                if (current.Value == valToFind)
                    return current;
                else if (valToFind < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return null;
        }


        //different insertion methods: Iterative and Recursive!
        
        //iterative insert method!
        public static void Insert_Iterative(int newVal)
        {
            TreeNode current = root;
            
            while (current != null)
            {
                //Console.WriteLine("iterative, comparing newval {0} against currentval {1}", newVal, current.Value);
                if (newVal < current.Value)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode(newVal);
                        break;
                    }
                    else 
                        current = current.Left;
                }
                else if (newVal > current.Value)
                {
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode(newVal);
                        break;
                    }
                    else 
                        current = current.Right;
                }
                else
                {
                    Console.WriteLine("Cannot insert duplicate.");
                }
            }
        }

        //recursive insert method!
        static void Insert_Recursive(int newVal, TreeNode current)
        {
           // Console.WriteLine("checking newval {0} against nodevalue {1}", newVal, current.Value);
            if (newVal < current.Value)
            {
                if (current.Left == null)
                    current.Left = new TreeNode(newVal);
                else
                    Insert_Recursive(newVal, current.Left);
            }
            else if (newVal > current.Value)
            {
                if (current.Right == null)
                    current.Right = new TreeNode(newVal);
                else
                    Insert_Recursive(newVal, current.Right);
            }
            else
            {
                Console.WriteLine("Cannot insert duplicate.");
            }
        }



        static TreeNode Add(int[] list, int startIndex, int endIndex)
        {
            if (startIndex > endIndex) return null;

            //find the middle index
            int middleIndex = (int)Math.Floor(((double)(startIndex) + (double)(endIndex))/2);

            TreeNode newNode = new TreeNode(list[middleIndex]);
            
            newNode.Left = Add(list, startIndex, middleIndex - 1);
            newNode.Right = Add(list, middleIndex + 1, endIndex);

            return newNode;

        }

       
    }
}
