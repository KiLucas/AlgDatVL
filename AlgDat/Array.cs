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
