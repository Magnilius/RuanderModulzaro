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
            Console.WriteLine($"A versenyzők akik először 1980ban léptek pályára:");
            List<Balkezes> eloszor = new List<Balkezes>();
            for (int j = 0; j < N; j++)
            {
                if (balkezesek[j].elso.Contains("1980"))
                {
                    eloszor.Add(balkezesek[j]);
                    Console.WriteLine(balkezesek[j].nev);
                }
            }

            //3. feladat
            Console.WriteLine("Adj meg egy nevet:");
            string bekertnev = Console.ReadLine();
            int eloszorN = eloszor.Count();
            int i = 0;
            while (i < eloszorN && bekertnev != eloszor[i].nev)
            {
                i++;
            }
            bool van = i < N;
            if (van)
            {
                Console.WriteLine($"A megadott játékos magassága: {eloszor[i].magassag * 2.54:F1} cm");
            }
            else
            {
                Console.WriteLine("Hibás adat");
            }

            //4. feladat
            Console.WriteLine("Adj meg egy évszámot");
            bool jo = false;
            int bekertEvszam = 0;
            do
            {
                bekertEvszam = int.Parse(Console.ReadLine());
                if (bekertEvszam >= 1900 && bekertEvszam <= 1999)
                {
                    jo = true;
                }
                else
                {
                    Console.WriteLine("Hibás");
                }
            } while (!jo);
            string bekertevszamstring = bekertEvszam + "";
            Console.WriteLine("Akik először léptek pályára ebben az évben:");
            for (int j = 0; j < N; j++)
            {
                if (balkezesek[j].elso.Contains(bekertevszamstring))
                {
                    Console.WriteLine(balkezesek[j].nev + " " + balkezesek[j].elso + " " + balkezesek [j].utolso + " " + balkezesek[j].magassag + " " + balkezesek[j].suly);
                }
            }



            Console.Read();
        }
    }
}
