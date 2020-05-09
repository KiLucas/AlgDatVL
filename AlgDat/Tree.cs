using System;
using System.Collections.Generic;
using System.Text;

namespace AlgDat
{
    class Tree
    {
        Node root;
        

        //Properties to access stuff
        public Node Root  
        { 
            get { return root; }
            set { root = value; }
        }

        //Constructors to build stuff
        public Tree(Node Root)
        {
            this.root = Root;
        }

        //traversing methods

        public static void TraverseInorder(Node n)
        {
            if (n != null)
            {
                TraverseInorder(n.left);
                Console.WriteLine(n.element);
                TraverseInorder(n.right);
            }
        }

        public static void TraversePreorder(Node n)
        {
            if (n != null)
            {
                Console.WriteLine(n.element);
                TraverseInorder(n.left);
                TraverseInorder(n.right);
            }
        }

        public static void TraversePostorder(Node n)
        {
            if (n != null)
            {
                TraverseInorder(n.left);
                TraverseInorder(n.right);
                Console.WriteLine(n.element);
            }
        }

        public static void Intendprint(Node n, int e) //hilfsmethode für treeprint
        {
            string intend = "";

            for (int i = 0; i < e; i++)
            {
                intend += "       ";
            }
            intend += "-- ";
            
            Console.WriteLine(intend + n.element);
        }

        public static void TreePrint(Node n, int e)
        {
            if (n != null)
            {
                TreePrint(n.right, e + 1);
                Intendprint(n, e);
                TreePrint(n.left, e + 1);
            }
        }


        
        //Subclass to use in-stuffed stuff
        public class Node
        {
            public int element;
            public Node left;
            public Node right;

            public Node()
            {

            }
            public Node(int element, Node left, Node right)
            {
                this.element = element;
                this.left = left;
                this.right = right;
            }
        }
    }
}
