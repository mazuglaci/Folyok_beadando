using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folyok_beadando
{
    class Bfeladat
    {
        public static int[] Sorolvas()
        {
            return Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        public static void BMegoldas()
        {
            int n, m, x, y;
            int[] input = Sorolvas();
            n = input[0];
            m = input[1];
            x = input[2];
            y = input[3];
            River[] rivers = new River[n + 1];
            for (int i = 1; i <= n; i++)
            {
                rivers[i] = new River(i);
            }
            int from, to;
            for (int i = 0; i < m; i++)
            {
                input = Sorolvas();
                from = input[0];
                to = input[1];
                rivers[from].SetEnd(rivers[to]);
            }
            SortedSet<int> tovabbFolyok = rivers[x].Leszarmazott();
            SortedSet<int> beleFolyok = new SortedSet<int>();
            rivers[x].Osszefolyike(ref beleFolyok);

            Console.WriteLine();
            Console.WriteLine($"{beleFolyok.Count} {string.Join(" ", beleFolyok)}");
            Console.WriteLine($"{tovabbFolyok.Count} {string.Join(" ", tovabbFolyok)}");
            Console.WriteLine();
        }
        private static void Osszefolyike(this River river)
        {
            foreach (River os in river.ContainedRivers)
            {
                
            }
        }

        private static SortedSet<int> Leszarmazott(this River river)
        {
            SortedSet<int> ret = new SortedSet<int>();

            return ret;
        }
    }
}

/*
6 4 6 5
1 2
3 4
4 5
3 6

IGEN
1 2
*/