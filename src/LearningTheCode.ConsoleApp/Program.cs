using LearningTheCode.Application;
using LearningTheCode.Infrastructure.Data;
using LearningTheCode.Infrastructure.Repositories;

Console.WriteLine("Welcome to LearningTheCode!");

// 1. Setup
var repo = new InMemoryExerciseRepository(); // Skapa först lagringen i infrastrukturen
var seeder = new ExerciseSeeder(repo); // Seedad data
var exerciseService = new ExerciseService(repo); // Initiate our first service

// 2. Fyll på seed data
seeder.Seed();

// 3. Hämta alla övningar och blanda dom
var allExercises = exerciseService.GetAllExercises();
var random = new Random();
var shuffledList = allExercises.OrderBy(x => random.Next()).ToList();

int score = 0; // Håll koll på poängen

// Loopa den blandade listan
foreach (var currentExercise in shuffledList)
{
    
    Console.Clear();
    Console.ResetColor(); // Resettar färgen
    
    // 4. Visa den slumpade frågan
    Console.WriteLine("--------------------------------------");
    Console.WriteLine($"CATEGORY: {currentExercise.Category.ToUpper()}");
    Console.WriteLine($"TASK:     {currentExercise.Description}");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine(currentExercise.CodeSnippet);
    Console.WriteLine();

// Receive answer
    Console.ForegroundColor = ConsoleColor.Yellow; // Gör texten gul när man skriver kod
    Console.Write("> "); 
    string input = Console.ReadLine() ?? "";
    Console.ResetColor();

// Check answer
    if (exerciseService.CheckAnswer(currentExercise, input))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n[✓] Correct! Well done.");
        score++;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n[X] Incorrect.");
        Console.ResetColor();
        Console.WriteLine($"The expected syntax was: {currentExercise.CorrectAnswer}");
    }
    
    Console.WriteLine("\nPress any key for the next question...");
    Console.ReadKey();
}

Console.Clear();
Console.WriteLine("======================================");
Console.WriteLine("           F I N A L  S C O R E       ");
Console.WriteLine("======================================");
Console.WriteLine($"\nYou got {score} out of {shuffledList.Count} correct!");

if (score == shuffledList.Count)
    Console.WriteLine("Perfect score! You're a C# beast! 🔥");
else
    Console.WriteLine("Good job! Keep practicing.");

Console.ResetColor();
Console.WriteLine("\nPress any key to exit.");
Console.ReadKey();

