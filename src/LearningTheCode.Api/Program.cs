using LearningTheCode.Application;
using LearningTheCode.Application.Interfaces;
using LearningTheCode.Infrastructure.Repositories;
using LearningTheCode.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICES (Dependency Injection)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExerciseSeeder>();


// Här registrerar du dina egna klasser från din Clean Architecture
builder.Services.AddSingleton<IExerciseRepository, InMemoryExerciseRepository>();
builder.Services.AddScoped<ExerciseService>();

// CORS - Viktigt för att React ska få prata med API:et senare
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();

// 2. MIDDLEWARE (Pipeline)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Detta gör att du kan gå till /swagger i webbläsaren
}

app.UseHttpsRedirection();
app.UseCors("AllowReact");

// Seed
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ExerciseSeeder>();
    seeder.Seed();
}

app.MapControllers(); // Detta mappar dina Controllers (som du skapar i nästa steg)

app.Run();


