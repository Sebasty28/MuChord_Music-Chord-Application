using MuChor_BusinessDataLogic;
namespace MuChord
{
    internal class Program
    {
        static ChordManager chordManager = new ChordManager();


        public static string[] guidelines = new string[]
     {
            "MuChord Application\n",
            "-- Application Guidelines --\n",
            "1. Chords consist of a Name, Type, and Notes/Diagram.",
            "2. Use the menu options to add, edit, search, or delete chords.",
            "3. Confirm before deleting a chord to prevent accidental loss.",
            "4. You can view the current saved chord at any time.",
            "5. Reset chord data to clear stored information.",
            "6. Input validation prevents empty entries.",
            "7. After every action, the menu will be displayed again.",
            "8. Select an option from the menu below:"
     };

        static void Main(string[] args)
        {
            foreach (var line in guidelines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("[1] Add Chord");
            Console.WriteLine("[2] Edit Chord");
            Console.WriteLine("[3] Search Chord");
            Console.WriteLine("[4] Delete Chord");
            Console.WriteLine("[5] View Current Chord");
            Console.WriteLine("[6] Reset Chord Data");
            Console.WriteLine("[7] Exit");

            while (true)
            {
                Console.Write("Choose Action: ");
                if (!int.TryParse(Console.ReadLine(), out int userChoice) || userChoice < 1 || userChoice > 7)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                    continue;
                }

                if (userChoice == 7) break;

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
                        ViewCurrentChord();
                        break;
                    case 6:
                        ResetChordData();
                        break;
                }
                foreach (var line in guidelines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("[1] Add Chord");
                Console.WriteLine("[2] Edit Chord");
                Console.WriteLine("[3] Search Chord");
                Console.WriteLine("[4] Delete Chord");
                Console.WriteLine("[5] View Current Chord");
                Console.WriteLine("[6] Reset Chord Data");
                Console.WriteLine("[7] Exit");
            }
        }

        static void AddChordFromInput()
        {
            string name, type, notes;
            do
            {
                Console.Write("Enter Chord Name: ");
                name = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("Enter Chord Type: ");
                type = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(type));

            do
            {
                Console.Write("Enter Chord Notes/Diagram: ");
                notes = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(notes));

            chordManager.SetChord(name, type, notes);
            Console.WriteLine("Chord Added Successfully!");
        }

        static void EditChordFromInput()
        {
            if (!chordManager.HasChord())
            {
                Console.WriteLine("No chord available to edit!");
                return;
            }

            string newName, newNotes;
            do
            {
                Console.Write("Update Chord Name: ");
                newName = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(newName));

            do
            {
                Console.Write("Update Chord Notes/Diagram: ");
                newNotes = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(newNotes));

            chordManager.EditChord(newName, newNotes);
            Console.WriteLine("Chord Updated Successfully!");
        }

        static void SearchChordFromInput()
        {
            string result = chordManager.GetChordInfo();
            Console.WriteLine(result);
        }

        static void DeleteChordFromInput()
        {
            Console.Write("Are you sure you want to delete the chord? (yes/no): ");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes" && chordManager.DeleteChord())
            {
                Console.WriteLine("Chord Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Deletion canceled or no chord available to delete!");
            }
        }

        static void ViewCurrentChord()
        {
            Console.WriteLine(chordManager.GetChordInfo());
        }

        static void ResetChordData()
        {
            chordManager.ResetChord();
            Console.WriteLine("Chord data has been reset!");
        }
    }
}