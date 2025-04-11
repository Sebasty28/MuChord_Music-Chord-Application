using MuChord_BL;
using MuChord_DL;
using System;

namespace MuChord
{
    internal class Program
    {
        static ChordManagers chordManager = new ChordManagers();

        static string[] guidelines =
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

            foreach (string line in guidelines)
            {
                Console.WriteLine(line);
            }

            while (true)
            {
                Console.Write("Choose Action: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.\n");
                    continue;
                }

                if ((MenuOption)choice == MenuOption.Exit)
                    break;

                switch ((MenuOption)choice)
                {
                    case MenuOption.Add:
                        AddChord();
                        break;
                    case MenuOption.Edit:
                        EditChord();
                        break;
                    case MenuOption.Search:
                        SearchChord();
                        break;
                    case MenuOption.Delete:
                        DeleteChord();
                        break;
                    case MenuOption.ViewAll:
                        Console.WriteLine(chordManager.GetAllChords());
                        break;
                }

                foreach (string line in guidelines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void AddChord()
        {
            Console.Write("Enter Chord Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Enter Chord Type (Major/Minor): ");
            string type = Console.ReadLine().Trim();

            ChordData chord = chordManager.GetChordDiagram(name, type);
            if (chord.notes == "Unknown chord")
            {
                Console.WriteLine("Invalid chord name or type.\n");
                return;
            }

            chordManager.AddChord(name, type, chord.notes);
            Console.WriteLine("Chord Added Successfully!\n");
        }

        static void EditChord()
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

        static void SearchChord()
        {
            Console.Write("Enter Chord Name to Search: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Enter Chord Type (Major/Minor): ");
            string type = Console.ReadLine().Trim();

            ChordData chord = chordManager.GetChord(name, type);
            if (chord != null)
                Console.WriteLine("Chord: " + chord.name + " - " + chord.type + " - " + chord.notes);
            else
                Console.WriteLine("Chord not found.\n");
        }

        static void DeleteChord()
        {
            Console.Write("Enter the Chord Name to Delete: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Are you sure you want to delete this chord? (yes/no): ");
            string confirm = Console.ReadLine().ToLower();

            if (confirm == "yes" && chordManager.DeleteChord(name))
                Console.WriteLine("Chord Deleted Successfully!\n");
            else
                Console.WriteLine("Deletion canceled or chord not found!\n");
        }
    }
}
