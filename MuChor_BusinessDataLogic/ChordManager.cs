
using MuChor_BusinessDataLogic;
using System.Xml.Linq;

namespace MuChor_BusinessDataLogic
{
    public class ChordManager
    {
        private Chord[] chords = new Chord[10];
        private int count = 0;

        public void AddChord(string name, string type, string notes)
        {
            if (count < chords.Length)
            {
                chords[count++] = new Chord(name, type, notes);
            }
        }

        public bool EditChord(string name, string newNotes)
        {
            for (int i = 0; i < count; i++)
            {
                if (chords[i].name == name)
                {
                    chords[i].notes = newNotes;
                    return true;
                }
            }
            return false;
        }

        public string GetChordInfo(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (chords[i].name == name)
                {
                    return "Chord: " + chords[i].name + " - " + chords[i].type + " - " + chords[i].notes;
                }
            }
            return "Chord not found";
        }

        public bool DeleteChord(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (chords[i].name == name)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        chords[j] = chords[j + 1];
                    }
                    chords[--count] = null;
                    return true;
                }
            }
            return false;
        }

        public string GetAllChords()
        {
            if (count == 0)
                return "No chords available.";

            string result = "Saved Chords:\n";
            for (int i = 0; i < count; i++)
            {
                result += "- " + chords[i].name + " - " + chords[i].type + " - " + chords[i].notes + "\n";
            }
            return result;
        }

        public static string GetChordDiagram(string name, string type)
        {
            if (name == "C" && type == "Major") return "C-E-G";
            if (name == "C#" && type == "Major") return "C#-E#-G#";
            if (name == "Db" && type == "Major") return "Db-F-Ab";
            if (name == "D" && type == "Major") return "D-F#-A";
            if (name == "D#" && type == "Major") return "D#-Fx-A#";
            if (name == "Eb" && type == "Major") return "Eb-G-Bb";
            if (name == "E" && type == "Major") return "E-G#-B";
            if (name == "F" && type == "Major") return "F-A-C";
            if (name == "F#" && type == "Major") return "F#-A#-C#";
            if (name == "Gb" && type == "Major") return "Gb-Bb-Db";
            if (name == "G" && type == "Major") return "G-B-D";
            if (name == "G#" && type == "Major") return "G#-B#-D#";
            if (name == "Ab" && type == "Major") return "Ab-C-Eb";
            if (name == "A" && type == "Major") return "A-C#-E";
            if (name == "A#" && type == "Major") return "A#-Cx-E#";
            if (name == "Bb" && type == "Major") return "Bb-D-F";
            if (name == "B" && type == "Major") return "B-D#-F#";

            if (name == "C" && type == "Minor") return "C-Eb-G";
            if (name == "C#" && type == "Minor") return "C#-E-G#";
            if (name == "Db" && type == "Minor") return "Db-E-Gb";
            if (name == "D" && type == "Minor") return "D-F-A";
            if (name == "D#" && type == "Minor") return "D#-F#-A#";
            if (name == "Eb" && type == "Minor") return "Eb-Gb-Bb";
            if (name == "E" && type == "Minor") return "E-G-B";
            if (name == "F" && type == "Minor") return "F-Ab-C";
            if (name == "F#" && type == "Minor") return "F#-A-C#";
            if (name == "Gb" && type == "Minor") return "Gb-A-C";
            if (name == "G" && type == "Minor") return "G-Bb-D";
            if (name == "G#" && type == "Minor") return "G#-B-D#";
            if (name == "Ab" && type == "Minor") return "Ab-Cb-Eb";
            if (name == "A" && type == "Minor") return "A-C-E";
            if (name == "A#" && type == "Minor") return "A#-C#-E#";
            if (name == "Bb" && type == "Minor") return "Bb-Db-F";
            if (name == "B" && type == "Minor") return "B-D-F#";

            return "Unknown chord";
        }

    }
}
