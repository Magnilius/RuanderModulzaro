using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulzaroRuander
{
    class Balkezes
    {
        public string nev { get; set; }
        public string elso { get; set; }
        public string utolso { get; set; }
        public int suly { get; set; }
        public int magassag { get; set; }

        public Balkezes(string sor)
        {
            string[] s = sor.Split(';');
            nev = s[0];
            elso = s[1];
            utolso = s[2];
            suly = int.Parse(s[3]);
            magassag = int.Parse(s[4]);
        }
    }
}
