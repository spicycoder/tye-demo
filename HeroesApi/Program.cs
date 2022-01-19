using HeroesApi.Clients;
using HeroesApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<HeroesService>();
builder.Services.AddHttpClient<ContactsClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:1801");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
