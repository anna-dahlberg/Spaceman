using System.ComponentModel.DataAnnotations;

namespace Spaceman;

public class Game
{
    private string codeword;
    private string currentWord;
    private int maxGuesses;
    private int numWrongGuesses;
    private string[] wordBank;
    private Ufo Ufo { get; set; }
    private List<string> WrongGuesses { get; set; }
    private HashSet<string> guessedLetters = new HashSet<string>();

    
    public Game()
    {
        wordBank = new string[] { "kebabkungen", "kebabrulle", "feferoni", "kebabsås", "extraallt" };
        Random random = new Random();
        codeword = wordBank[random.Next(wordBank.Length)];
        maxGuesses = 5;
        numWrongGuesses = 0;
        currentWord = new string('_', codeword.Length);
        Ufo = new Ufo();
        WrongGuesses = new List<string>();
    }
    
    public void Greet()
    {
        Console.WriteLine("Welcome to Spaceman!");
        Console.WriteLine("Try to guess the word before the alien abducts you.");
        Console.WriteLine("Good luck, earthling!\n");
    }
    
    public void Ask()
    {
        Console.Write("Guess a letter: ");
        string guess = Console.ReadLine()?.ToLower();
        
        if (string.IsNullOrEmpty(guess) || guess.Length != 1)
        {
            Console.WriteLine("Please enter one letter at a time.");
            return;
        }
        
        if (!char.IsLetter(guess[0]))
        {
            Console.WriteLine("Please enter a valid letter (a-z).");
            return;
        }
        
        if (guessedLetters.Contains(guess))
        {
            Console.WriteLine($"You've already guessed '{guess}'. Try a different letter.");
            return;
        }
        guessedLetters.Add(guess);

        if (codeword.Contains(guess))
        {
            Console.WriteLine($"Good guess! {guess} is in the word.");
            UpdateCurrentWord(guess);
        }
        else
        {
            Console.WriteLine($"Sorry, {guess} is not in the word.");
            WrongGuesses.Add(guess);  
            numWrongGuesses++;
            Ufo.AddPart();  
        }
    }
    
    private void UpdateCurrentWord(string guess)
    {
        for (int i = 0; i < codeword.Length; i++)
        {
            if (codeword[i].ToString() == guess)
            {
                currentWord = currentWord.Remove(i, 1).Insert(i, guess);
            }
        }
    }
    
    public void Display()
    {
        Console.WriteLine(Ufo.Stringify());
        Console.WriteLine("Current word: " + currentWord);
        Console.WriteLine("Guesses remaining: " + (maxGuesses - numWrongGuesses));
        Console.WriteLine("Wrong guesses: " + string.Join(", ", WrongGuesses));
    }

    public bool DidWin()
    {
        return currentWord.Equals(codeword);
    }

    public bool DidLose()
    {
       return numWrongGuesses >= maxGuesses;
    }
}
