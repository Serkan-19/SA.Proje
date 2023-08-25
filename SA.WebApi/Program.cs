using SA.Business;
using SA.WebApi;
using SA.WebApi.Middlewares;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddBusinessServices();
builder.Services.AddApiServices();



var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger(); 
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.UseCustomExeption();
app.Run();
public class MyTransparentJsonNamingPolicy : JsonNamingPolicy
{
    // You can came up any custom transformation here, so instead just transparently
    // pass through the original C# class property name, it is possible to explicit
    // convert to PascalCase, etc:
    public override string ConvertName(string name)
    {
        var camelCase = name.Substring(0, 1).ToLowerInvariant();
        camelCase = camelCase + name.Substring(1, name.Length - 1);
        return camelCase;
    }
}
