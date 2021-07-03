using System;

namespace TypeRace
{
    static class Input
    {
        public static char GetUserChar()
        {
            return Console.ReadKey(true).KeyChar;
        }

    }
}
