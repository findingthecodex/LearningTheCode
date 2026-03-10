using LearningTheCode.Domain;
using LearningTheCode.Application;

Console.WriteLine("Welcome to LearningTheCode!");

// Initiate our first service

var exerciseService = new ExerciseService();

// Create a test-exercise
var firstExercise = new Exercise
{
    Language = "C#",
    Category = "Logic",
    Description = "Which keyboard represents a true or false value?",
    CodeSnippet = "___ isCodingFun = true;",
    CorrectAnswer = "bool"
};

// Add exercise in service-list
exerciseService.AddExercise(firstExercise);

Console.WriteLine($"\nCategory: {firstExercise.Category}");
Console.WriteLine($"Task: {firstExercise.Description}");
Console.WriteLine($"Code: {firstExercise.CodeSnippet}");

// Receive answer
Console.Write("\nYour Answer:");
string input = Console.ReadLine() ?? "";

// Check answer

if (exerciseService.CheckAnswer(firstExercise, input))
{
    Console.WriteLine("Correct! Well done.");
}
else
{
    Console.WriteLine($"Incorrect. The right answer is: {firstExercise.CorrectAnswer}");
}