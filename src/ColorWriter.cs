using System;

namespace TypeRace
{
    static class ColorWriter
    {
        public static void WriteBackground(ConsoleColor color, string message)
        {
            Console.BackgroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void WriteLineBackground(ConsoleColor color, string message)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
