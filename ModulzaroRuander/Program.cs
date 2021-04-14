using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulzaroRuander
{
    class Program
    {
        static void Main(string[] args)
        {

            //file beolvasása
            string[] sorok = File.ReadAllLines("balkezesek.csv");
            List<Balkezes> balkezesek = new List<Balkezes>();

            foreach (string sor in sorok.Skip(1))
            {
                balkezesek.Add(new Balkezes(sor));
            }

            //1. feladat
            int N = balkezesek.Count();
            Console.WriteLine($"1. Feladat: A balkezesek száma {N}");

            //2. feladat
            int eloszor = 0;


            Console.Read();
        }
    }
}
