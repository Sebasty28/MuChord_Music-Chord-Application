using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuChor_BusinessDataLogic
{
    public class Chord
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }

        public Chord(string name, string type, string notes)
        {
            Name = name;
            Type = type;
            Notes = notes;
        }
    }
}
