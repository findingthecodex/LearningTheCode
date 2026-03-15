using LearningTheCode.Domain;

namespace LearningTheCode.Application.Interfaces;

// Detta är ett kontrakt - ingen kod eller logik, mer som en meny på en resturang, vad som finns.
public interface IExerciseRepository
{
    void Add(Exercise exercise);
    List<Exercise> GetAll();
    Exercise? GetById(Guid id);
} 