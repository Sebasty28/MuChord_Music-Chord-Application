
namespace MuChord_DL
{
    public class ChordData
    {
        public string name;
        public string type;
        public string notes;

        public ChordData(string name, string type, string notes)
        {
            this.name = name;
            this.type = type;
            this.notes = notes;
        }

        public void UpdateNotes(string newNotes)
        {
            notes = newNotes;
        }
    }

}

