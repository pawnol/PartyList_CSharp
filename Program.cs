/*
 * Party List
 * Pawelski
 * 2/14/2022
 * Please follow the instructions on the activity sheet to analyze
 * the program below.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyList
{
    class Program
    {
        // Please add the correct file path to access the file 
        // "InviteList.txt" in the bin/Debug folder.
        private const string FILE_PATH = @"";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party List application.");
            while(true)
            {
                int choice;
                Console.WriteLine("Here are the following actions you can perform...");
                Console.WriteLine("(1) Display the party invite list.");
                Console.WriteLine("(2) Add a name to the party invite list.");
                Console.WriteLine("(3) Remove a name from the party invite list.");
                Console.WriteLine("(4) Exit the program.");
                Console.Write("Enter your choice >> ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    DisplayList();
                }
                else if(choice == 2)
                {
                    string name;
                    Console.Write("Enter the name to add to the invite list >> ");
                    name = Console.ReadLine();
                    AddName(name);
                }
                else if(choice == 3)
                {
                    string name;
                    Console.Write("Enter the name to remove from the invite list >> ");
                    name = Console.ReadLine();
                    RemoveName(name);
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
                Console.WriteLine();
            }
        }

        /*
         * Displays the names in the invite list to the console. These names are
         * stored in a file.
         */
        private static void DisplayList()
        {
            FileStream file = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while(!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }
            reader.Close();
            file.Close();
        }

        /*
         * Adds the specified name from the invite list stored in the file.
         * nameToAdd represents the name to add to the invite list
         */
        private static void AddName(string nameToAdd)
        {
            FileStream file = new FileStream(FILE_PATH, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(nameToAdd);
            writer.Close();
            file.Close();
        }

        /*
         * Removes the specified name from the invite list stored in the file.
         * nameToRemove represents the name to remove from the invite list
         */
        private static void RemoveName(string nameToRemove)
        {
            // Stores the names from the file into a list.
            FileStream fileRead = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileRead);
            List<string> inviteList = new List<string>();
            while (!reader.EndOfStream)
            {
                inviteList.Add(reader.ReadLine());
            }
            reader.Close();
            fileRead.Close();

            // Removes the name from the list.
            inviteList.Remove(nameToRemove);

            // Stores the names back into the file.
            FileStream fileWrite = new FileStream(FILE_PATH, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileWrite);
            for(int i = 0; i < inviteList.Count; i++)
            {
                writer.WriteLine(inviteList[i]);
            }
            writer.Close();
            fileWrite.Close();
        }
    }
}
