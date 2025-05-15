using CarInfoApp.Application.Interfaces;
using CarInfoApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

//  Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  HttpClient 
builder.Services.AddHttpClient<INhtsaService, NhtsaService>();

var app = builder.Build();

// Swagger 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//  Razor Pages
app.UseStaticFiles();
app.MapRazorPages();

//   API
app.MapControllers();

app.Run();
