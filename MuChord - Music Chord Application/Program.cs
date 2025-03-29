using MuChor_BusinessDataLogic;
namespace MuChord
{
    internal class Program
    {
        static ChordManager chordManager = new ChordManager();

        public static string[] guidelines =
        {
            "Select an option from the menu below:\n",
            "[1] Add Chord",
            "[2] Edit Chord",
            "[3] Search Chord",
            "[4] Delete Chord",
            "[5] View All Chord",
            "[6] Exit\n",
         };

        static void Main(string[] args)
        {
            Console.WriteLine("MuChord\n");

            foreach (var line in guidelines)
            {
                Console.WriteLine(line);
            }
            while (true)
            {
                Console.Write("Choose Action: ");
                if (!int.TryParse(Console.ReadLine(), out int userChoice) || userChoice < 1 || userChoice > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.\n");
                    continue;
                }

                if (userChoice == 6) break;

                switch (userChoice)
                {
                    case 1:
                        AddChord();
                        break;
                    case 2:
                        EditChord();
                        break;
                    case 3:
                        SearchChord();
                        break;
                    case 4:
                        DeleteChord();
                        break;
                    case 5:
                        ViewAllChords();
                        break;
                }
                foreach (var line in guidelines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void AddChord()
        {
            Console.Write("Enter Chord Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Chord Type (Major/Minor): ");
            string type = Console.ReadLine();

            string notes = ChordManager.GetChordDiagram(name, type);

            chordManager.AddChord(name, type, notes);
            Console.WriteLine("Chord added successfully!\n");
        }

        static void EditChord()
        {
            Console.Write("Enter Chord Name to Edit: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Chord Notes: ");
            string newNotes = Console.ReadLine();

            if (chordManager.EditChord(name, newNotes))
                Console.WriteLine("Chord updated successfully!\n");
            else
                Console.WriteLine("Chord not found!\n");
        }

        static void SearchChord()
        {
            Console.Write("Enter Chord Name to Search: ");
            string name = Console.ReadLine();
            Console.WriteLine(chordManager.GetChordInfo(name));
        }

        static void DeleteChord()
        {
            Console.Write("Enter Chord Name to Delete: ");
            string name = Console.ReadLine();

            if (chordManager.DeleteChord(name))
                Console.WriteLine("Chord deleted successfully!\n");
            else
                Console.WriteLine("Chord not found or could not be deleted!\n");
        }

        static void ViewAllChords()
        {
            Console.WriteLine(chordManager.GetAllChords());
        }
    }
}