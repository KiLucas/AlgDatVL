using System;
using System.Xml;

namespace AlgDat
{
    class Program
    {

        static int SequSearch(int[]array, int x)
        {
            int index;
            array[array.Length - 1] = x;
            index = 0;
            while (array[index] != x)
            {
                index += 1;
            }
            return index;
        } //Aus AlgDat Folie [39]

        static int BinSearch(int[]a, int x) //Aus AlgDat Folie [44]
        {
            int l, r, i;
            l = 0;
            r = a.Length - 2;
            i = 0;

            bool stop = false;
            while (l>r || stop == false)
            {
                i = Convert.ToInt32((l + r) / 2);
                if (a[i] < x)
                {
                    l = i + 1;
                }
                else
                {
                    r = i - 1;
                }

                if (a[i]==x)
                {
                    stop = true;
                }
            }

            if (a[i] == x)
            {
                return i;
            }
            return -1;
        } 

        static Tree.Node Search(Tree t, int e) //Binary Tree Search method (AlgDat Folie [60])
        {
            Console.WriteLine("---- entering Search Method ----");
            Tree.Node a = t.Root;
            while (a.element != e && a != null)
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
            
            if (a!=null)
            {
                Console.WriteLine("Found Element " +a.element);
            }
            else
            {
                Console.WriteLine("a not found!");
            }
            Console.WriteLine("---- exiting Search Method ----");
            return a;
        }

        (Tree.Node ,Tree.Node, string) Search(Tree.Node a, int e) //helping method for Delete AlgDat[75]
        {
            Tree.Node preda=null;
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
        static void Delete(Tree t, int e)
        {
            Tree.Node b = null;
            Tree.Node preda = null;
            Tree.Node a = t.Root;

            string dir="";
            Console.WriteLine("---- now inside Delete Method (node called a, element e) ----");

            if (a == null) //no element e => dont do anything
            {
                Console.WriteLine("a is null");
                Console.WriteLine("---- exiting Delete Method ----");
                return;
            }
            /////
            if (a.right != null && a.left !=null) // element e has two descendants
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

        static void DelSymPred(Tree.Node a)
        {
            Tree.Node b, c;

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

        static void Insert(Tree t, int e)
        {
            Tree.Node a = t.Root;
            Tree.Node b = null;

            while (a!=null && a.element != e )
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
                a = new Tree.Node(e, null,null);
                
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
            
        static void Main(string[] args)
        {
            //used to test SequSearch and BinSearch methods
            //int[] test = { 2, 4, 7, 16, 28, 37, 56, 57, 59, 70, 71, 85, 89, 94, 107, 138, 142 };
            //Console.WriteLine(SequSearch(test, 70));

            Tree test = new Tree(new Tree.Node(45, null, null));
            int[] tarray = { 18, 10, 41, 43, 67, 56, 66, 59, 59, 57, 64, 97, 95 };


            foreach  (int i in tarray)
            {
                Insert(test, i); 
            }

            Tree.Node testsearch = Search(test, 95);

            Console.WriteLine(testsearch.element);

            Delete(test, 95);

            if (Search(test,95) == null)
            {
                Console.WriteLine("95 deleted");

            }
            Console.WriteLine("Searching..");

            if (Search(test,95) == null)
            {

            }

            
        }
    }
}
