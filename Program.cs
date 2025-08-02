using itransition_task5_server.DTOs;
using itransition_task5_server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IBookGenerator, BookGenerator>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "Open API");
    });
}

app.MapGet("/api/books", (
    [AsParameters] BookRequestDto req,
    IBookGenerator bookGen) =>
{
    if (!new[] { "ru", "en", "de" }.Contains(req.Locale))
        return Results.BadRequest("Invalid locale");

    var books = bookGen.GenerateBooks(req);
    return Results.Ok(books);
});


app.Run();


