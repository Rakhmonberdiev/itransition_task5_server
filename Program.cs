using FluentValidation;
using itransition_task5_server.DTOs;
using itransition_task5_server.Services;
using itransition_task5_server.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IBookGenerator, BookGenerator>();
builder.Services.AddValidatorsFromAssemblyContaining<BookRequestDtoValidator>();
builder.Services.AddOutputCache();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowClient", policy =>
    {
        policy
          .WithOrigins("https://task5.jr-blog.uz")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();

    });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "Open API");
    });
}
app.UseCors("AllowClient");
app.UseOutputCache();
app.MapGet("/api/books", (
[AsParameters] BookRequestDto req,
    IValidator <BookRequestDto> validator,
    IBookGenerator bookGen) =>
{
    var result =  validator.Validate(req);
    if (!result.IsValid) return Results.ValidationProblem(result.ToDictionary());
    var books = bookGen.GenerateBooks(req);
    return Results.Ok(books);
}).CacheOutput(policy => policy
    .Expire(TimeSpan.FromMinutes(1))
    .SetVaryByQuery("locale", "seed", "avgLikes", "avgReviews", "page", "pageSize")
);


app.Run();


