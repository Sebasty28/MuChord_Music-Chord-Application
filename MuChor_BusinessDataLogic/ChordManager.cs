
namespace MuChor_BusinessDataLogic
{
    public class ChordManager
    {
        private Chord chord;

        public void SetChord(string name, string type, string notes)
        {
            chord = new Chord(name, type, notes);
        }

        public void EditChord(string newName, string newNotes)
        {
            if (chord != null)
            {
                chord.Name = newName;
                chord.Notes = newNotes;
            }
        }

        public string GetChordInfo()
        {
            if (chord != null)
            {
                return "Chord: " + chord.Name + " - " + chord.Type + " - " + chord.Notes;
            }
            return "No chord available";
        }

        public bool DeleteChord()
        {
            if (chord != null)
            {
                chord = null;
                return true;
            }
            return false;
        }

        public bool HasChord()
        {
            return chord != null;
        }

        public void ResetChord()
        {
            chord = null;
        }
    }
}