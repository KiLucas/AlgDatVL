using System;
using System.Collections.Generic;
using System.Text;

namespace AlgDat
{
    class Tree
    {
        Node root;
        
        //Cosmetic
        public static void PrintBanner()
        {
            Console.WriteLine(@"  ____  _                          _______            ");
            Console.WriteLine(@" |  _ \(_)                        |__   __|           ");
            Console.WriteLine(@" | |_) |_ _ __   __ _ _ __ _   _     | |_ __ ___  ___ ");
            Console.WriteLine(@" |  _ <| | '_ \ / _` | '__| | | |    | | '__/ _ \/ _ \");
            Console.WriteLine(@" | |_) | | | | | (_| | |  | |_| |    | | | |  __/  __/");
            Console.WriteLine(@" |____/|_|_| |_|\__,_|_|   \__, |    |_|_|  \___|\___|");
            Console.WriteLine(@"                            __/ |                     ");
            Console.WriteLine(@"                           |___/                      ");
        }
        
        public static void PrintSuggestions()
        {
            Console.WriteLine("Press Backspace to go back one menue.");
            Console.WriteLine("Press I to insert a node to a tree.");
            Console.WriteLine("Press C to create a new tree.");
            Console.WriteLine("Press 1 to traverse your tree PreOrder");
            Console.WriteLine("Press 2 to traverse your tree Inorder");
            Console.WriteLine("Press 3 to traverse your tree Postorder");
            Console.WriteLine("Press D to delete a node from your tree");
            Console.WriteLine("Press P to print your Tree with a grapical solution");
        }

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

        public static Node Search(Tree t, int e) //Binary Tree Search method (AlgDat Folie [60])
        {
            Console.WriteLine("---- entering Search Method ----");
            Node a = t.Root;
            while (a != null && a.element != e)
            {
                if (e < a.element)
                {
                    a = a.left;
                }
                else
                {
                    a = a.right;
                }
            }

            if (a != null)
            {
                Console.WriteLine("Found Element " + a.element);
            }
            else
            {
                Console.WriteLine("a not found!");
            }
            Console.WriteLine("---- exiting Search Method ----");
            return a;
        }

        public static (Node, Node, string) Search(Node a, int e) //helping method for Delete AlgDat[75]
        {
            Node preda = null;
            string dir = "";
            while (a != null)
            {
                if (e < a.element)
                {
                    preda = a;
                    a = a.left;
                    dir = "left";
                }
                else if (e > a.element)
                {
                    preda = a;
                    a = a.right;
                    dir = "right";
                }
                else
                {
                    break;
                }
            }
            return (a, preda, dir);
        }
        public static void Delete(Tree t, int e)
        {
            Node b = null;
            Node preda = null;
            Node a = t.Root;

            string dir = "";
            (a, preda, dir) = Search(a, e);


            Console.WriteLine("---- now inside Delete Method (node called a, element e) ----");

            if (a == null) //no element e => dont do anything
            {
                Console.WriteLine("a is null");
                Console.WriteLine("---- exiting Delete Method ----");
                return;
            }
            /////
            if (a.right != null && a.left != null) // element e has two descendants
            {
                DelSymPred(a);
                Console.WriteLine("element has two descendants, deleting Symmetrical Pred...");
                Console.WriteLine("---- exiting Delete Method ----");
                return;
            }
            /////
            if (a.left == null) //element e has one descendant
            {
                Console.WriteLine("element has one descendant");
                Console.WriteLine("deleting..");
                b = a.right;
            }
            else
            {
                Console.WriteLine("element has one descendant");
                Console.WriteLine("deleting..");
                b = a.left;
            }
            //////
            if (t.Root == a)
            {
                t.Root = b;
                Console.WriteLine("a is root");
                Console.WriteLine("---- exiting Delete Method ----");
                return;
            }
            /////
            if (dir == "left")
            {
                preda.left = b;
            }
            else
            {
                preda.right = b;
            }
            Console.WriteLine("---- exiting Delete Method ----");
            Console.WriteLine();
            Console.WriteLine();
            return;

        }

        public static void DelSymPred(Node a)
        {
            Node b, c;

            b = a;

            if (b.left.right != null)
            {
                b = b.left;
                while (b.right.right != null)
                {
                    b = b.right;
                }
            }

            if (b == a)
            {
                c = b.left;
                b.left = c.left;
            }
            else
            {
                c = b.right;
                b.right = c.left;
            }
            a.element = c.element;
        }

        public static void Insert(Tree t, int e)
        {
            Node a = t.Root;
            Node b = null;

            while (a != null && a.element != e)
            {
                b = a;
                if (e < a.element)
                {
                    a = a.left;
                }
                else
                {
                    a = a.right;
                }
            }
            if (a == null)
            {
                a = new Node(e, null, null);

                if (b == null)
                {
                    t.Root = a;
                    return;
                }
                if (e < b.element)
                {
                    b.left = a;
                }
                else
                {
                    b.right = a;
                }
            }
        } //Binary Tree Insert Method (AlgDat Folie [64])
    }
}
