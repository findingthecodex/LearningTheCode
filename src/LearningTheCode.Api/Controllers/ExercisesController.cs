using LearningTheCode.Application;
using Microsoft.AspNetCore.Mvc;
using LearningTheCode.Domain;

namespace LearningTheCode.Api.Controllers;

[ApiController]
[Route("api/[controller]")] // Detta gör att URL:en blir http://localhost:XXXX/api/exercises
public class ExercisesController : ControllerBase
{
    private readonly ExerciseService _exerciseService;
    
    // Här händer magin: ASP.NET ser att du vill ha en ExerciseService 
    // och hämtar den vi registrerade i Program.cs (Dependency Injection)
    public ExercisesController(ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }
    
    // En enkel GET-metod för att hämta alla frågor
    [HttpGet]
    public IActionResult Get()
    {
        var exercises = _exerciseService.GetAllExercises();
        return Ok(exercises);
    }
}