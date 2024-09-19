using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOptions<MvcOptions>().PostConfigure<IOptions<JsonOptions>>((opt, jOptions) =>
{
    var inputFormat = opt.InputFormatters.OfType<SystemTextJsonInputFormatter>().First();
    inputFormat.SupportedMediaTypes.Add(
        new MediaTypeHeaderValue("application/json+testea")
    );
    inputFormat.SupportedMediaTypes.Add(
        new MediaTypeHeaderValue("application/json+testeb")
    );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => opt.ResolveConflictingActions(api => api.First()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
