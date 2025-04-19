namespace Spaceman;

public class Game
{
    private string codeword;
    private string currentWord;
    private int maxGuesses;
    private int numWrongGuesses;
    private string[] wordBank;
    private Ufo ufo;

    public bool DidIWin()
    {
        return currentWord.Equals(codeword);
    }

    public bool DidILose()
    {
       return numWrongGuesses >= maxGuesses;
    }

    public Game()
    {
        wordBank = new string[] { "kebabkungen", "kebabrulle", "feferoni", "kebabsås", "extraallt" };
        Random random = new Random();
        codeword = wordBank[random.Next(wordBank.Length)];
        maxGuesses = 5;
        numWrongGuesses = 0;
        currentWord = new string('_', codeword.Length);
    }
    public void Greet()
    {
        Console.WriteLine("Welcome to Spaceman!");
        Console.WriteLine("Try to guess the word before the alien takes you.");
        Console.WriteLine("Good luck, earthling!\n");
    }
}