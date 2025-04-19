namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(); 
            game.Greet(); 
            
            while (!game.DidWin() && !game.DidLose())
            {
                game.Display(); 
                game.Ask(); 
            }
            
            if (game.DidWin())
            {
                Console.WriteLine("Congratulations! You've cracked the code and stopped the abduction!");
            }
            else
            {
                Console.WriteLine("Game over! The abduction was completed. Better luck next time!");
            }
        }
    }
}