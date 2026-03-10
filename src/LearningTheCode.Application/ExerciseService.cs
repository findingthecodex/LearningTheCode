using LearningTheCode.Domain;

namespace LearningTheCode.Application;

public class ExerciseService
{
    // List to hold our exercises
    private readonly List<Exercise> _exercises = new();

    // Method to add a new exercise
    public void AddExercise(Exercise exercise)
    {
        _exercises.Add(exercise);
    }
    
    // Method to get all exercises (example show a list)
    public List<Exercise> GetAllExercises()
    {
        return _exercises;
    }
    
    // A method to check answer - logic belongs in Application
    public bool CheckAnswer(Exercise exercise, string userAnswer)
    {
        // Check answer - trims the answer if user types with ex space
        return exercise.CorrectAnswer.Trim().Equals(userAnswer.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}