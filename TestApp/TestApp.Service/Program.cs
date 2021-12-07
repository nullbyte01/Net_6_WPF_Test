
using TestApp.Shared.Models;
using TestApp.Service.Helper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<InformationHelper>(); //Injecting Dependency in service by using singleton pattern object

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/api/all", (InformationHelper informationHelper) =>
{
    return informationHelper.GetAllInformations();
});

app.MapGet("/api/{id}", (InformationHelper informationHelper, int id) =>
{
    return informationHelper.GetAllInformation(id);
});

app.MapPost("/api", (InformationHelper informationHelper, Information information) =>
{
    return informationHelper.AddInformation(information);
});

app.MapPut("/api/{id}", (InformationHelper informationHelper, int id, Information information) =>
{
    return informationHelper.UpdateInformation(id, information);
});

app.MapDelete("/api/{id}", (InformationHelper informationHelper, int id) =>
{
    return informationHelper.DeleteInformation(id);
});


app.Run();
