using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folyok_beadando
{
    static class Bfeladat
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
            List<int> elso = new List<int>();             //x. leszármazottai
            Console.WriteLine(elso);
            List<int> masodik = new List<int>();            //y. leszármazottai
            Console.WriteLine(masodik);
            Console.WriteLine(elso[x]);            //mi az első közös
            //első = -1 => "NEM"
            if (elso[x].Elsokozos(elso) = -1)
            { Console.WriteLine("NEM"); }
            else
            {elso.IndexOf(elso) + 1; //indexof()+1 --> hányadik x listája
             masodik.IndexOf(masodik) + 1; //indexof()+1 --> hányadik y listája 
            }

        }

        //a folyók leszármazottainak megadása
        private static List<int> Leszarmazott(this River eredeti)
        {
            List<int> ret = new List<int>();
            River vizsgalt = eredeti;
            while (vizsgalt.HasEndRiver)
            {
                vizsgalt = vizsgalt.EndRiver;
                ret.Add(vizsgalt.ID);
            }

            return ret;
        }
        //első közös leszármazott megadása
        private static int Elsokozos(List<int> elso, List<int> masodik)
        {
            int i = 0;
            while (i < elso.Count && !masodik.Contains(elso[i])) 
            {
                i++;
            }
            if (i < elso.Count)
            {
                return elso[i];
            }
            else 
            {
                return -1;
            }
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