using System;

namespace GissaTal
{
    class Program
    {

        static int randomNumber(int min, int max){
            Random random = new Random();
            return random.Next(min, max);
        }

        static int getInput(){
            while(true){
                Console.WriteLine("Gissa ett tal mellan 0 och 100: ");
                string input = Console.ReadLine();
                int guess;

                bool validNumber = Int32.TryParse(input, out guess);

                if (!validNumber){
                    Console.WriteLine("Ogiltig gissning, försök igen!");
					continue;
                }
                else if (validNumber){
                    return guess;
                }
            }
        }

        static void Main(string[] args)
        {
            int attempts = 0;
            int guess = -1;
            int number = randomNumber(0, 100);

            while(guess != number){
                guess = getInput();
                attempts++;

                if (guess == number){
                    Console.WriteLine(guess + " är Rätt svar!");
                    Console.WriteLine("Det tog dig " + attempts + " gissningar.");
                }
                else if (guess > number){
                    Console.WriteLine(guess + " är för stort!");
                }
                else if (guess < number){
                    Console.WriteLine(guess + " är för litet!");
                }
            }

        }
    }
}
