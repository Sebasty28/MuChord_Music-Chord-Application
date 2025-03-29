
using MuChor_BusinessDataLogic;
using System.Xml.Linq;

namespace MuChor_BusinessDataLogic
{
    public class ChordManager
    {
        private Chord [] chords = new Chord[10];
        private int chordCounter = 0;
        

        public void AddChord(string name, string type, string notes)
        {
            if(chordCounter < chords.Length)
            {
                chords[chordCounter++] = new Chord(name, type, notes);
            }
        }

        public bool EditChord(string newName, string newNotes)
        {
            for (int i = 0; i < chordCounter; i++)
            {
                if (chords[i].Name == newName)
                {
                    chords[i].Notes = newNotes;
                    return true;
                }
            }
            return false;
        }

        public string GetChordInfo(string name)
        {
            for (int i = 0; i < chordCounter; i++)
            {
                if (chords[i].Name == name)
                {
                    return "Chord: " + chords[i].Name + " - " + chords[i].Type + " - " + chords[i].Notes;
                }
            }
            return "Chord not found";
        }

        public bool DeleteChord(string name)
        {
            for (int i = 0; i < chordCounter; i++)
            {
                if (chords[i].Name == name)
                {
                    for (int j = i; j < chordCounter - 1; j++)
                    {
                        chords[j] = chords[j + 1];
                    }
                    chords[--chordCounter] = null;
                    return true;
                }
            }
            return false;
        }

        public string GetAllChords()
        {
            if (chordCounter == 0)
                return "No chords available";

            string result = "Saved Chords:\n";
            for (int i = 0; i < chordCounter; i++)
            {
                result += "- " + chords[i].Name + " - " + chords[i].Type + " - " + chords[i].Notes + "\n";
            }
            return result;
        }

    }
}

