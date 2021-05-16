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

        public static void AMegoldas()
        {
            int n, m, f;
            int[] input = Sorolvas();
            n = input[0];
            m = input[1];
            f = input[2];
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
        }
        }
}
