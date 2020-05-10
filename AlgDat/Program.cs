using System;
using System.Linq;
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

        static void PrintSuggestions()
        {
            Console.WriteLine("Press 1 to use binary tree program");
            Console.WriteLine("Press 2 to use Array program");
        }

        static void Main(string[] args)
        {
            
            
            Tree maintree = null;
            // While loop to run the programm
            ConsoleKeyInfo input;
            do // Outer Loop - Dictionary
            {
                Console.Clear();
                PrintBanner();
                PrintSuggestions();
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    do // Inner Loop - Binary Tree
                    {


                        Console.Clear();
                        Tree.PrintBanner();
                        Tree.PrintSuggestions();

                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.C)
                        {
                            Tree.PrintCreateSuggestions();
                            int rootinput = Convert.ToInt32(Console.ReadLine());
                            maintree = new Tree(new Tree.Node(rootinput,null,null));
                        }
                        if (input.Key == ConsoleKey.I)
                        {
                            Tree.PrintInsertSuggestions();
                            int nodeinput = Convert.ToInt32(Console.ReadLine());
                            Tree.Insert(maintree, nodeinput);
                        }
                        if (input.Key == ConsoleKey.D)
                        {
                            Tree.PrintDeleteSuggestions();
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
                            Tree.PrintPreOrderSuggestions();
                            Tree.TraversePreorder(maintree.Root);
                        }
                        if (input.Key == ConsoleKey.D2)
                        {
                            Tree.PrintInOrderSuggestions();
                            Tree.TraverseInorder(maintree.Root);
                        }
                        if (input.Key == ConsoleKey.D3)
                        {
                            Tree.PrintPostOrderSuggestions();
                            Tree.TraversePostorder(maintree.Root);
                        }

                    } while (input.Key != ConsoleKey.Backspace);

                }
                if (input.Key == ConsoleKey.D2)
                {
                    int[] mainarray = new int[2000];
                    int length = 0;

                    do // Inner Loop - Array
                    {
                        Console.Clear();
                        Array.PrintBanner();
                        Console.WriteLine();
                        Array.PrintSuggestions();
                        input = Console.ReadKey();
                        

                        
                        if (input.Key == ConsoleKey.A)
                        {
                            Array.PrintAppendSuggestions();
                            int inputint = Convert.ToInt32(Console.ReadLine());
                            mainarray[length] = inputint;
                            length++;
                            Console.WriteLine("succesfully appended " + inputint + " to array");
                            Console.ReadKey();
                        }
                        if (input.Key == ConsoleKey.P)
                        {
                            Array.PrintPrintSuggestions();
                            Array.PrintArray(mainarray, length);
                            Console.ReadKey();
                        }
                        if (input.Key == ConsoleKey.D1)
                        {
                            Array.PrintSequSuggestions();
                            int inputint = Convert.ToInt32(Console.ReadLine());
                           
                            if (mainarray.Contains(inputint))
                            {
                                int index = Array.SequSearch(mainarray, inputint);
                                Console.WriteLine("Found " + inputint + " at index: " + index );
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine(inputint + " is not in the array");
                                Console.ReadKey();
                            }
                        }

                        

                    } while (input.Key != ConsoleKey.Backspace);
                }
                
                
                //input = Console.ReadKey();

            } while (input.Key != ConsoleKey.Escape);
        }
    }
}
