using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] choices = { "rock", "paper", "scissors" };
            Random random = new Random();
            bool playAgain = true;
            int playerScore = 0;
            int computerScore = 0;

            while (playAgain)
            {
                int userChoiceIndex = GetUserChoice();
                if (userChoiceIndex == -1) continue;

                string userChoice = choices[userChoiceIndex - 1];
                string computerChoice = choices[random.Next(choices.Length)];

                Console.WriteLine($"You chose {userChoice}");
                Console.WriteLine($"Computer chose {computerChoice}");

                string result = DetermineWinner(userChoice, computerChoice);
                Console.WriteLine(result);

                if (result == "You win!") playerScore++;
                else if (result == "You lose!") computerScore++;

                playAgain = AskToPlayAgain();
            }

            Console.WriteLine($"Final Score - Player: {playerScore}, Computer: {computerScore}");
        }

        static int GetUserChoice()
        {
            Console.WriteLine("Choose an option: 1 for rock, 2 for paper, 3 for scissors:");
            string userInput = Console.ReadLine();
            int userChoiceIndex;

            if (!int.TryParse(userInput, out userChoiceIndex) || userChoiceIndex < 1 || userChoiceIndex > 3)
            {
                Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
                return -1;
            }

            return userChoiceIndex;
        }

        static string DetermineWinner(string userChoice, string computerChoice)
        {
            if (userChoice == computerChoice)
            {
                return "It's a tie!";
            }
            else if ((userChoice == "rock" && computerChoice == "scissors") ||
                     (userChoice == "paper" && computerChoice == "rock") ||
                     (userChoice == "scissors" && computerChoice == "paper"))
            {
                return "You win!";
            }
            else
            {
                return "You lose!";
            }
        }

        static bool AskToPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (yes/no)");
            return Console.ReadLine().ToLower() == "yes";
        }
    }
}