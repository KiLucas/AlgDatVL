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
                Console.WriteLine(n);
                TraverseInorder(n.right);
            }
        }

        public static void TraversePreorder(Node n)
        {
            if (n != null)
            {
                Console.WriteLine(n);
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
                Console.WriteLine(n);
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
