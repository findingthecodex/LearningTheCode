using LearningTheCode.Application.Interfaces;
using LearningTheCode.Domain;

namespace LearningTheCode.Infrastructure.Data;

public class ExerciseSeeder
{
    private readonly IExerciseRepository _repository;

    public ExerciseSeeder(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public void Seed()
    {
        // Vi lägger bara till om listan är tom (så vi inte dubblerar varje gång)
        if (_repository.GetAll().Any()) return;

        var initialExercise = new List<Exercise>
        {
            new Exercise
            {
                Language = "C#",
                Category = "Logic",
                Description = "Write a standard for-loop that runs 10 times (use 'i' as variable).",
                CodeSnippet = "// Write your code below:",
                CorrectAnswer = "for(int i = 0; i < 10; i++)"
            },
            
            new Exercise 
            { 
                Id = Guid.NewGuid(),
                Language = "C#", 
                Category = "Arrays & Loops", 
                Description = "Fullfölja koden för att skriva ut varje siffra i arrayen.",
                CodeSnippet = "int[] nums = { 1, 2, 3 }; \nforeach (int n in nums) \n{ \n  __________ \n}",
                CorrectAnswer = "Console.WriteLine(n);" 
            },
            
            new Exercise 
            { 
                Id = Guid.NewGuid(),
                Language = "C#", 
                Category = "Variables", 
                Description = "Skapa två heltal, 'x' med värdet 5 och 'y' med värdet 10. Addera dem och skriv ut resultatet.",
                CodeSnippet = "int x = 5;\nint y = 10;\n// Skriv koden för att printa summan:",
                CorrectAnswer = "Console.WriteLine(x + y);" 
            }
        };

        foreach (var ex in initialExercise)
        {
            _repository.Add(ex);
        }
    }
}