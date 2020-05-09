using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace AlgDat
{
    class Program
    {
        
        static void PrintBanner()
        {
            Console.WriteLine(@"  _____  _      _   _                        _");
            Console.WriteLine(@" |  __ \(_)    | | (_)                      (_)          ");
            Console.WriteLine(@" | |  | |_  ___| |_ _  ___  _ __   __ _ _ __ _  ___  ___ ");
            Console.WriteLine(@" | |  | | |/ __| __| |/ _ \| '_ \ / _` | '__| |/ _ \/ __|");
            Console.WriteLine(@" | |__| | | (__| |_| | (_) | | | | (_| | |  | |  __/\__ \");
            Console.WriteLine(@" |_____/|_|\___|\__|_|\___/|_| |_|\__,_|_|  |_|\___||___/");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            
            
            Tree maintree = null;
            //while loop to run the programm
            ConsoleKeyInfo input;
            do //outer Loop - Dictionary
            {
                Console.Clear();
                PrintBanner();
                Console.WriteLine("Press 1 to use binary tree program");
                Console.WriteLine("Press 2 to use Array program");
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    do //innter Loop - Binary Tree
                    {


                        Console.Clear();
                        Tree.PrintBanner();
                        Tree.PrintSuggestions();

                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.C)
                        {
                            Console.WriteLine("--- Create a new Tree ---");
                            Console.WriteLine("enter the root node of your integer tree and press enter: ");
                            int rootinput = Convert.ToInt32(Console.ReadLine());
                            maintree = new Tree(new Tree.Node(rootinput,null,null));
                        }
                        if (input.Key == ConsoleKey.I)
                        {
                            Console.WriteLine("--- Insert a node to your Tree ---");
                            Console.WriteLine("enter the new node of you integer tree and press enter: ");
                            int nodeinput = Convert.ToInt32(Console.ReadLine());
                            Tree.Insert(maintree, nodeinput);
                        }
                        if (input.Key == ConsoleKey.D)
                        {
                            Console.WriteLine("--- Delete a node of your Tree ---");
                            Console.WriteLine("enter the node to be deleted in your tree");
                            int delinput = Convert.ToInt32(Console.ReadLine());
                            Tree.Delete(maintree, delinput);
                        }
                        if (input.Key == ConsoleKey.P)
                        {
                            Console.WriteLine();
                            Tree.TreePrint(maintree.Root, 0);
                            Console.ReadKey();
                        }
                        if (input.Key == ConsoleKey.D1)
                        {
                            Console.WriteLine("Traversing tree preorder");
                            Tree.TraversePreorder(maintree.Root);
                        }
                        if (input.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine("Traversing tree inorder");
                            Tree.TraverseInorder(maintree.Root);
                        }
                        if (input.Key == ConsoleKey.D3)
                        {
                            Console.WriteLine("Traversing tree postorder");
                            Tree.TraversePostorder(maintree.Root);
                        }

                        

                    } while (input.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D2)
                {
                    Array.PrintBanner();
                }
                
                
                //input = Console.ReadKey();

            } while (input.Key != ConsoleKey.Escape);
        }
    }
}
