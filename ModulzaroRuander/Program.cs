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
            bool van = i < 8;
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

            //5. feladat
            DateTime legkisebb = DateTime.Now;
            foreach (Balkezes balkez in balkezesek)
            {
                if (balkez.elsodate < legkisebb)
                {
                    legkisebb = balkez.elsodate;
                }
            }
            Console.WriteLine($"A legkorábbi dátum {legkisebb}");

            //6. feladat
            bool igen = false;
            foreach (Balkezes balkez in balkezesek)
            {
                if (balkez.utolsodate.Year >= 2000)
                {
                    igen = true;
                }
            }
            if (igen)
            {
                Console.WriteLine("Van olyan játékos aki 2000 után lépett pályára");
            }
            else
            {
                Console.WriteLine("Nincs olyan játékos aki 2000 után lépett pályára");
            }

            //7. feladat
            Console.WriteLine("Az emberek akinek John van a nevében:");
            foreach (Balkezes balkez in balkezesek)
            {
                if (balkez.nev.Contains("John"))
                {
                    Console.Write(balkez.nev + " ");
                }
            }
            Console.WriteLine("");
            //8. feladat
            Dictionary<string, int> nevek = new Dictionary<string, int>();
            List<string> keresett = new List<string>();
            foreach (Balkezes balkez in balkezesek)
            {
                if (balkez.keresztnev == "Joe" || balkez.keresztnev == "John" || balkez.keresztnev == "Jim" || balkez.keresztnev == "Jack")
                {
                    keresett.Add(balkez.keresztnev);
                }
            }
            foreach (string keres in keresett)
            {
                string kulcs = keres;
                if (nevek.ContainsKey(kulcs))
                {
                    nevek[kulcs]++;
                }
                else
                {
                    nevek.Add(kulcs, 1);
                }
            }
            List<string> kiirando = new List<string>();
            foreach (var item in nevek)
            {
                kiirando.Add($"{item.Key} keresztnévből {item.Value}");
                Console.WriteLine($"{item.Key} keresztnévből {item.Value}");
            }

            File.WriteAllLines("kernevek.txt", kiirando);


            Console.Read();
        }
    }
}
