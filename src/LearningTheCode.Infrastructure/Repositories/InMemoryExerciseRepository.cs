using LearningTheCode.Application.Interfaces;
using LearningTheCode.Domain;

namespace LearningTheCode.Infrastructure.Repositories;

/// <summary>
/// 
/// </summary>
public class InMemoryExerciseRepository : IExerciseRepository
{
    // Här lever listan nu istället för i Service
    private readonly List<Exercise> _exercises = new();
    public void Add(Exercise exercise) => _exercises.Add(exercise);
    public List<Exercise> GetAll() => _exercises;
    public Exercise? GetById(Guid id) => _exercises.FirstOrDefault(e => e.Id == id);
}