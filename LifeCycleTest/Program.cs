using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LifeCycleTest
{
    class Program
    {

        


        static void Main()
        {
            bool pass = Evaluate();
            if (pass)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.WriteLine("tast for å fortsette");
                Console.ReadKey();
            }
        }

        private static bool Evaluate()
        {
            var entries = new List<string>(Constants.Fasit.Length);
            string input;
            do
            {
                input = GetInput();
                entries.Add(input);
                if (IsCorrect(entries))
                {
                    WriteEntries(entries, ConsoleColor.Green);
                }
                else
                {
                    WriteError();
                    entries = new List<string>();

                }
            } while (input != "q" && !HasPassed(entries));

            return !HasPassed(entries);
        }

        private static void WriteError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Feil!");
            WriteEntries(Constants.Fasit, ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("tast for å fortsette");
            Console.ReadKey(); 
            Console.Clear();
        }

        private static void WriteEntries(IEnumerable<string> entries, ConsoleColor consoleColor)
        {
            var oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
            Console.ForegroundColor = oldcolor;
        }

        private static bool IsCorrect(IEnumerable<string> entries)
        {
            return !entries.Where((entry, i) => entry.ToLower() != Constants.Fasit[i].ToLower()).Any();
        }

        private static bool HasPassed(IEnumerable<string> entries)
        {
            if (!IsCorrect(entries))
                return false;
            return entries.Count() == Constants.Fasit.Length;
        }

        private static string GetInput()
        {
            string input = "";
            string suggestion = "";
            do
            {
                var consoleKey = Console.ReadKey(true);
                Console.Clear();
                if (consoleKey.Key == ConsoleKey.Enter)
                    return suggestion;

                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    if (input.Length - 1 >= 0)
                        input = input.Substring(0, input.Length - 1);
                }
                if (consoleKey.KeyChar.IsLetter())
                {
                    input += consoleKey.KeyChar;
                }
                string comp = input;
                suggestion = Constants.Fasit.FirstOrDefault(item => item.StartsWith(comp, true, new CultureInfo("en")));
                Console.WriteLine(!string.IsNullOrEmpty(suggestion) ? suggestion : "?");

                Console.WriteLine(input);
            } while (true);
        }
    }

    public static class Ext
    {
        public static bool IsLetter( this char consoleKey)
        {
            return Constants.Alphabet.Contains(consoleKey.ToString().ToLower());
        }
    }
}
