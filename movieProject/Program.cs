using movieProject.MovieServices;
using movieProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddScoped<IMovieService,MovieService>();




builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://jemmimah-moviefrontend.vercel.app") 
               .AllowAnyHeader()
               .AllowAnyMethod()
               .WithExposedHeaders("Authorization"); // This adds the custom authorization header to response
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
