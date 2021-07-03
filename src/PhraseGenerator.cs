using System;

namespace TypeRace
{
    class PhraseGenerator
    {
        public static string GetRandomPhrase()
        {
            string[] phrases = GetPhrases();

            Random rand = new Random();
            int phraseIndex = rand.Next(0, phrases.Length);

            return phrases[phraseIndex];
        }

        private static string[] GetPhrases()
        {
            string[] phrases = new string[]
            {
            "Well, what can I tell you? Life in the wide world goes on much as it has this past Age, full of its own comings and goings, scarcely aware of the existence of Hobbits, for which I am very thankful.",
            "Mordor. The one place in Middle-Earth we don't want to see any closer. And it's the one place we're trying to get to. It's just where we can't get. Let's face it, Mr. Frodo, we're lost.",
            "Some people by nature are kind and charitable. You could say that some people, including at least one person at this table, are by their nature heroes. Ben always reminded me that we each contain all the nobler and meaner aspects of humanity, but some get a bigger dose than others of one thing or another."
            };

            return phrases;
        }
    }
}
