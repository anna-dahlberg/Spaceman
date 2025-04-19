using System.ComponentModel.DataAnnotations;

namespace Spaceman;

public class Game
{
    private string codeword;
    private string currentWord;
    private int maxGuesses;
    private int numWrongGuesses;
    private string[] wordBank;
    private Ufo ufo;
    
    public void Ask()
    {
        Console.Write("Guess a letter: ");
        string guess = Console.ReadLine();
        
        if (guess.Length != 1)
        {
            Console.WriteLine("Please enter one letter at a time.");
            return;
        }
        
        if (codeword.Contains(guess))
        {
            Console.WriteLine($"Good guess! {guess} is in the word.");
            
            for (int i = 0; i < codeword.Length; i++)
            {
                if (codeword[i].ToString() == guess)
                {
                    currentWord = currentWord.Remove(i, 1).Insert(i, guess);
                }
            }
        }
        else
        {
            Console.WriteLine($"Sorry, {guess} is not in the word.");
            numWrongGuesses++;
            ufo.AddPart(); 
        }
    }


    public void Display()
    {
        Console.WriteLine(ufo.Stringify());
        Console.WriteLine("Current word: " + currentWord);
        Console.WriteLine("Guesses remaining: " + (maxGuesses - numWrongGuesses));
    }

    public bool DidWin()
    {
        return currentWord.Equals(codeword);
    }

    public bool DidLose()
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