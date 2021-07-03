using System;
using System.Threading;

namespace TypeRace
{
    class Game
    {
        TimeKeeper timeKeeper = new TimeKeeper();
        string randomPhrase;
        int currentUserIndex;
        int nbWords;
        int nbMistakes;

        public static void Main(string[] args)
        {
            new Game().Start();
        }

        public void Start()
        {
            randomPhrase = PhraseGenerator.GetRandomPhrase();
            BeforeStartPresentation();
            Countdown(3);
            Gameplay();
            EndingMessage();
        }

        private void BeforeStartPresentation()
        {
            Console.WriteLine("The phrase to type is the following :\r\n");
            Console.WriteLine("\"" + randomPhrase + "\"");
            Console.WriteLine("\r\nPress \"Enter\" to start the game...");
            Console.ReadLine();
        }

        private void Countdown(int seconds)
        {
            Console.WriteLine(seconds);
            while (seconds > 0)
            {
                Thread.Sleep(1000);
                seconds--;
                Console.WriteLine(seconds);
            }
        }

        private void Gameplay()
        {
            timeKeeper.Start();

            while (!UserHasWrittenAllThePhrase())
            {
                ShowUI();
                char userLetter = Input.GetUserChar();
                char currentLetter = randomPhrase[currentUserIndex];

                if (userLetter == currentLetter)
                {
                    currentUserIndex++;
                }
                else
                {
                    nbMistakes++;
                }

                CheckWordTyped();
            }

            timeKeeper.Stop();
        }

        private bool UserHasWrittenAllThePhrase()
        {
            return currentUserIndex == randomPhrase.Length;
        }

        private void ShowUI()
        {
            Console.Clear();
            ShowTypingSpeed();
            ShowMistakes();
            ShowPhraseState();
        }

        private void ShowTypingSpeed()
        {
            double timeElapsed = (double) timeKeeper.GetTimeElapsedInMinutes();
            double wpmSpeed = nbWords / timeElapsed;
            wpmSpeed = Math.Round(wpmSpeed);

            if (nbWords == 0)
            {
                Console.WriteLine($"0 WPM");
            }
            else
            {
                Console.WriteLine($"{wpmSpeed} WPM");
            }
        }

        private void ShowMistakes()
        {
            Console.WriteLine($"Number of mistakes made : {nbMistakes}");
        }

        private void ShowPhraseState()
        {
            Console.WriteLine();
            if (currentUserIndex > 0)
            {
                string phraseCompleted = randomPhrase.Substring(0, currentUserIndex);
                Console.Write(phraseCompleted);
            }
            
            char currentLetter = randomPhrase[currentUserIndex];
            ColorWriter.WriteBackground(ConsoleColor.Red, Char.ToString(currentLetter));

            string phraseToBeCompleted = randomPhrase.Substring(currentUserIndex+1);
            Console.WriteLine(phraseToBeCompleted);
        }

        private void CheckWordTyped()
        {
            // the definition of "word" is standardized to be five characters
            if ((currentUserIndex != 0) && (currentUserIndex % 5 == 0))
            {
                nbWords++;
            }
        }

        private void EndingMessage()
        {
            Console.WriteLine("\r\nGame finished !");
            Console.WriteLine($"You lasted {timeKeeper.GetTimeElapsedInSeconds()} seconds");
            Console.ReadLine();
        }
    }
}
