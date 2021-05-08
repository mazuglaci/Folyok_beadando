using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folyok_beadando {
    static class Afeladat {
        public static int[] Sorolvas() {
            return Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        public static void AMegoldas() {
            int n, m, f;
            int[] input = Sorolvas();
            n = input[0];
            m = input[1];
            f = input[2];
            River[] rivers = new River[n + 1];
            for (int i = 1; i <= n; i++) {
                rivers[i] = new River(i);
            }
            int from, to;
            for(int i=0;i<m;i++) {
                input = Sorolvas();
                from = input[0];
                to = input[1];
                rivers[from].SetEnd(rivers[to]);
            }
            SortedSet<int> tovabbFolyok = rivers[f].MindenLeszarmazott();
            SortedSet<int> beleFolyok = new SortedSet<int>();
            rivers[f].MindenOs(ref beleFolyok);
            Console.WriteLine();
            Console.WriteLine($"{beleFolyok.Count} {string.Join(" ", beleFolyok)}");
            Console.WriteLine($"{tovabbFolyok.Count} {string.Join(" ", tovabbFolyok)}");
            Console.WriteLine();
        }

        private static void MindenOs(this River river, ref SortedSet<int> osId) {
            foreach(River os in river.ContainedRivers) {
                osId.Add(os.ID);
                os.MindenOs(ref osId);
            }
        }

        private static SortedSet<int> MindenLeszarmazott(this River river) {
            SortedSet<int> ret = new SortedSet<int>();
            River cur = river;
            while(cur.HasEndRiver) {
                cur = cur.EndRiver;
                ret.Add(cur.ID);
            }
            return ret;
        }


    }
}

/*
5 4 1
1 2
3 2
4 1
5 4

*/