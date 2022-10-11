using System;

namespace ConsoleClient
{
    public static class Menu
    {
        /// <summary>
        /// Display all startup options.
        /// </summary>
        public static void displayMenu()
        {
            Console.WriteLine("[1] add a new teacher");
            Console.WriteLine("[2] update a teacher");
            Console.WriteLine("[3] remove a teacher");
            Console.WriteLine("[4] list all teachers");
            Console.WriteLine("[5] list all courses of a teacher");
            Console.WriteLine("[6] add a new course");
            Console.WriteLine("[7] update a course");
            Console.WriteLine("[8] remove a course");
            Console.WriteLine("[9] list all courses");
            Console.WriteLine("[0] exit");
        }

        /// <summary>
        /// Clear console and print seperator.
        /// </summary>
        public static void clearMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// Display search options: name or id.
        /// </summary>
        public static void displaySearchOptions()
        {
            Console.WriteLine("[1] find by name");
            Console.WriteLine("[2] find by id");
        }
    }
}
