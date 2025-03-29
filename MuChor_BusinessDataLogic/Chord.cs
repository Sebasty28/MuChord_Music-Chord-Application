using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuChor_BusinessDataLogic
{
    public class Chord
    {
        public string name;
        public string type;
        public string notes;

        public Chord(string n, string t, string nts)
        {
            name = n;
            type = t;
            notes = nts;

        }
    }
}
