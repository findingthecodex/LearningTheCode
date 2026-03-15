using System.Runtime.CompilerServices;
using LearningTheCode.Domain;
using LearningTheCode.Application.Interfaces;

namespace LearningTheCode.Application;

public class ExerciseService
{
    // Interface kontraktet
    private readonly IExerciseRepository _repository;

    // konstruktor - Säger "För att jag ska starta, måste jag få något som följer IExerciseRepository"
    public ExerciseService(IExerciseRepository repository)
    {
        _repository = repository;
    }
    
    // Sparar till repository
    public void AddExercise(Exercise exercise)
    {
        _repository.Add(exercise);
    }
    
    // Hämtar listan från repositoryt
    public List<Exercise> GetAllExercises()
    {
        return _repository.GetAll();
    }
        
    // A method to check answer - logic belongs in Application
    public bool CheckAnswer(Exercise exercise, string userAnswer)
    {
        if (string.IsNullOrWhiteSpace(userAnswer)) return false;

        string cleanCorrect = exercise.CorrectAnswer.Replace(" ", "").Trim();
        string cleanUser = userAnswer.Replace(" ", "").Trim();
        
        // Check answer - trims the answer if user types with ex space
        return cleanCorrect.Equals(cleanUser, StringComparison.OrdinalIgnoreCase);
    }
}