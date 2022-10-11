using System;

namespace ConsoleClient
{
    public static class Validator
    {
        /// <summary>
        /// Get an input and validate it as an integer between 0 - 9.
        /// </summary>
        /// <returns>Numeric selection of user.</returns>
        public static int getMenuInput()
        {
            int input = checkNumericality();
            while (input < 0 || input > 9)
            {
                Console.WriteLine("Not a valid selection.");
                input = checkNumericality();
            }
            return input;
        }

        /// <summary>
        /// Get an input and validate it as an integer between 1 - 2.
        /// </summary>
        /// <returns>Numeric selection of user.</returns>
        public static int getOptionInput()
        {
            int input = checkNumericality();
            while (input != 1 && input != 2)
            {
                Console.WriteLine("Not a valid selection.");
                input = checkNumericality();
            }
            return input;
        }

        /// <summary>
        /// Get an input and validate it as an integer.
        /// </summary>
        /// <returns>An ID.</returns>
        public static int getId()
        {
            int id = checkNumericality();
            return id;
        }

        /// <summary>
        /// Try to parse a console input and return it if successful.
        /// </summary>
        /// <returns>An integer.</returns>
        private static int checkNumericality()
        {
            int number;
            do
            {
                Console.WriteLine("Enter a numeric selection: ");
            } while (!int.TryParse(Console.ReadLine(), out number));

            return number;
        }
    }
}
