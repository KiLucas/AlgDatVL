using System;
using System.Collections.Generic;
using System.Text;

namespace AlgDat
{
    class Array
    {
        
        public static void PrintBanner()
        {
            Console.WriteLine(@"                                ");
            Console.WriteLine(@"     /\                         ");
            Console.WriteLine(@"    /  \   _ __ _ __ __ _ _   _ ");
            Console.WriteLine(@"   / /\ \ | '__| '__/ _` | | | |");
            Console.WriteLine(@"  / ____ \| |  | | | (_| | |_| |");
            Console.WriteLine(@" /_/    \_\_|  |_|  \__,_|\__, |");
            Console.WriteLine(@"                           __/ |");
            Console.WriteLine(@"                          |___/ ");
            
        }

        public static void PrintSuggestions()
        {
            Console.WriteLine("To Fill the Array just use the append function");
            Console.WriteLine("no need to specifically create an array, just append your first number");
            Console.WriteLine("To append an integer press A");
            Console.WriteLine("To print your array press P");
            Console.WriteLine("To use the Sequential Search Method, press 1");
            Console.WriteLine("To go back to the menu before, press backspace");
        }

        public static void PrintAppendSuggestions()
        {
            Console.WriteLine("Enter the Integer to be appended to the Array: ");
        }

        public static void PrintPrintSuggestions()
        {
            Console.WriteLine("printing your Array in a Line and a space in between:");
        }

        public static void PrintSequSuggestions()
        {
            Console.WriteLine("--- Sequential Search ---");
            Console.WriteLine("Enter the integer you are searching for and press enter");
            
        }


        //Methods

        public static void PrintArray(int[]array, int alength)
        {
            for (int i = 0; i < alength; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
              
        public static int SequSearch(int[] array, int x)
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

        public static int BinSearch(int[] a, int x) //Aus AlgDat Folie [44]
        {
            int l, r, i;
            l = 0;
            r = a.Length - 2;
            i = 0;

            bool stop = false;
            while (l > r || stop == false)
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

                if (a[i] == x)
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
    }
}
