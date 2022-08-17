using fs_engineer_test_api.Apis;
using fs_engineer_test_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc();

builder.Services.AddTransient<IChuckApi, ChuckApi>();
builder.Services.AddTransient<ISwapiApi, SwapiApi>();
builder.Services.AddTransient<ISearchApi, SearchApi>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy(name: "AllowBlazorOrigin",
    build =>
    {
        build.WithOrigins("http://localhost:5000", "https://localhost:7000/");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
