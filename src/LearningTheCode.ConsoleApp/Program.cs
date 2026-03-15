using LearningTheCode.Domain;
using LearningTheCode.Application;
using LearningTheCode.Infrastructure.Repositories;
using LearningTheCode.Application.Interfaces;

Console.WriteLine("Welcome to LearningTheCode!");

// Skapa först lagringen i infrastrukturen
var repo = new InMemoryExerciseRepository();

// Initiate our first service
var exerciseService = new ExerciseService(repo);

// Create a test-exercise
var firstExercise = new Exercise
{
    Language = "C#",
    Category = "Logic",
    Description = "Write a standard for-loop that runs 10 times (use 'i' as variable).",
    CodeSnippet = "// Write your code below:",
    CorrectAnswer = "for(int i = 0; i < 10; i++)"
};

// Add exercise in service-list
exerciseService.AddExercise(firstExercise);

// Console.WriteLine($"\nCategory: {firstExercise.Category}");
// Console.WriteLine($"Task: {firstExercise.Description}");
// Console.WriteLine($"Code: {firstExercise.CodeSnippet}");
//
// // Receive answer
// Console.Write("\nYour Answer:");
// string input = Console.ReadLine() ?? "";
//
// // Check answer
// if (exerciseService.CheckAnswer(firstExercise, input))
// {
//     Console.WriteLine("Correct! Well done.");
// }
// else
// {
//     Console.WriteLine($"Incorrect. The right answer is: {firstExercise.CorrectAnswer}");
// }

// ... (din befintliga kod ovan)

Console.WriteLine("--------------------------------------");
Console.WriteLine($"CATEGORY: {firstExercise.Category.ToUpper()}");
Console.WriteLine($"TASK:     {firstExercise.Description}");
Console.WriteLine("--------------------------------------");
Console.WriteLine(firstExercise.CodeSnippet);

// Receive answer
Console.ForegroundColor = ConsoleColor.Yellow; // Gör texten gul när man skriver kod
Console.Write("> "); 
string input = Console.ReadLine() ?? "";
Console.ResetColor();

// Check answer
if (exerciseService.CheckAnswer(firstExercise, input))
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n[✓] Correct! Well done.");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n[X] Incorrect.");
    Console.ResetColor();
    Console.WriteLine($"The expected syntax was: {firstExercise.CorrectAnswer}");
}