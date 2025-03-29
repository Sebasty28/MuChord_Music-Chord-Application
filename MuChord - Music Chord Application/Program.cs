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
                        AddChordFromInput();
                        break;
                    case 2:
                        EditChordFromInput();
                        break;
                    case 3:
                        SearchChordFromInput();
                        break;
                    case 4:
                        DeleteChordFromInput();
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

        static void AddChordFromInput()
        {
            string name, type, notes;
            do 
            { Console.Write("Enter Chord Name: "); 
                name = Console.ReadLine().Trim(); 
            } while (string.IsNullOrEmpty(name));

            do 
            { Console.Write("Enter Chord Type: "); 
                type = Console.ReadLine().Trim(); 
            } while (string.IsNullOrEmpty(type));

            do 
            { Console.Write("Enter Chord Notes/Diagram: "); 
                notes = Console.ReadLine().Trim(); } 
            while (string.IsNullOrEmpty(notes));

            chordManager.AddChord(name, type, notes);
            Console.WriteLine("Chord Added Successfully!\n");
        }

        static void EditChordFromInput()
        {
            Console.Write("Enter the Chord Name to Edit: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Update Chord Notes/Diagram: ");
            string newNotes = Console.ReadLine().Trim();

            if (chordManager.EditChord(name, newNotes))
                Console.WriteLine("Chord Updated Successfully!\n");
            else
                Console.WriteLine("Chord not found!\n");
        }

        static void SearchChordFromInput()
        {
            Console.Write("Enter Chord Name to Search: ");
            string name = Console.ReadLine().Trim();
            Console.WriteLine(chordManager.GetChordInfo(name));
        }

        static void DeleteChordFromInput()
        {
            Console.Write("Enter the Chord Name to Delete: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Are you sure you want to delete this chord? (yes/no): ");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation == "yes" && chordManager.DeleteChord(name))
                Console.WriteLine("Chord Deleted Successfully!\n");
            else
                Console.WriteLine("Deletion canceled or chord not found!\n");
        }

        static void ViewAllChords()
        {
            Console.WriteLine(chordManager.GetAllChords());
        }
 
    }
}
   