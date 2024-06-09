using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.DbContexts;
using UnivaliMapas.Api.Extensions;
using UnivaliMapas.Api.Features.Salas.Commands.CreateSala;
using UnivaliMapas.Api.Repositories;
using UnivaliMapas.Features.Usuarios.Commands.CreateUser;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Injeção de repositórios
builder.Services.AddScoped<IUnivaliRepository, UnivaliRepository>();

// Injeção de validadores
builder.Services.AddScoped<IValidator<CreateSalaCommand>, CreateSalaCommandValidator>();
builder.Services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(setupAction =>
    {
        setupAction.SuppressModelStateInvalidFilter = true;
        setupAction.InvalidModelStateResponseFactory = context =>
        {
            // Cria a fábrica de um objeto de detalhes de problema de validação
            var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();

            //Cria um objeto de detalhes de problema de validação
            var validationProblemDetails = problemDetailsFactory
                .CreateValidationProblemDetails(
                    context.HttpContext,
                    context.ModelState
                );

            // Adiciona informações adicionais não adicionadas por padrão
            validationProblemDetails.Detail = "See the errors field for details.";
            validationProblemDetails.Instance = context.HttpContext.Request.Path;

            // Relata respostas do estado de modelo invalido como problemas de validacao
            validationProblemDetails.Type =
                "https://univalimapas.com/modelvalidationproblem";
            validationProblemDetails.Status =
                StatusCodes.Status422UnprocessableEntity;
            validationProblemDetails.Title =
                "One or more validation errors occurred.";

            return new UnprocessableEntityObjectResult(validationProblemDetails)
            {
                ContentTypes = { "application/problem+json" }
            };
        };
    }
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UnivaliContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

await app.ResetDatabaseAsync();

app.Run();
