using MuChord_DL;
using System;

namespace MuChord_BL
{
    public class ChordManagers
    {
        private List<ChordData> chords = new List<ChordData>();

        public void AddChord(string name, string type, string notes)
        {
            chords.Add(new ChordData(name, type, notes));
        }

        public bool EditChord(string name, string newNotes)
        {
            ChordData chord = null;
            foreach (var chrd in chords)
            {
                if (chrd.name == name)
                {
                    chord = chrd;
                    break;
                }
            }
            if (chord == null) return false;
            chord.UpdateNotes(newNotes);
            return true;
        }

        public ChordData GetChord(string name, string type)
        {
            foreach (var chrd in chords)
            {
                if (chrd.name == name && chrd.type == type)
                    return chrd;
            }
            return null;
        }

        public bool DeleteChord(string name)
        {
            ChordData chord = null;
            foreach (var chrd in chords)
            {
                if (chrd.name == name)
                {
                    chord = chrd;
                    break;
                }
            }
            if (chord != null)
            {
                chords.Remove(chord);
                return true;
            }
            return false;
        }

        public string GetAllChords()
        {
            if (chords.Count == 0)
            {
                return "No chords available";
            }

            string result = "Saved Chords:\n";

            foreach (ChordData chord in chords)
            {
                result += "- " + chord.name + " - " + chord.type + " - " + chord.notes + "\n";
            }
            return result.TrimEnd();
        }

        public ChordData GetChordDiagram(string name, string type)
        {
            string notes = GenerateChordNotes(name, type);
            return new ChordData(name, type, notes);
        }

        private string GenerateChordNotes(string root, string type)
        {
            string[] sharpNotes = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string[] flatNotes = { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

            int index = -1;
            string[] selectedNotes = sharpNotes;

            for (int i = 0; i < sharpNotes.Length; i++)
            {
                if (sharpNotes[i] == root)
                {
                    index = i;
                    selectedNotes = sharpNotes;
                    break;
                }
                else if (flatNotes[i] == root)
                {
                    index = i;
                    selectedNotes = flatNotes;
                    break;
                }
            }

            if (index == -1) return "Unknown chord";

            int thirdInterval = type.ToLower() == "major" ? 4 : 3;
            int fifthInterval = 7;

            int thirdIndex = index + thirdInterval;
            if (thirdIndex >= 12)
            {
                thirdIndex -= 12;
            }

            int fifthIndex = index + fifthInterval;
            if (fifthIndex >= 12)
            {
                fifthIndex -= 12;
            }

            string thirdNote = selectedNotes[thirdIndex];
            string fifthNote = selectedNotes[fifthIndex];

            return root + "-" + thirdNote + "-" + fifthNote;
        }
    }
}