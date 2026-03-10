namespace LearningTheCode.Domain;

public class Exercise
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Language { get; set; } = string.Empty;
    public string Description { get; set; }
    public string Category { get; set; } = string.Empty;
    
    // The code with a hole ("int x = ___ 10;")
    public string CodeSnippet { get; set; } = string.Empty;
    public string CorrectAnswer { get; set; } = string.Empty;
    public int Difficulty { get; set; }
}