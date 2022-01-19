using Dapr.Client;
using HeroesApi.Clients;
using HeroesApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDaprClient();
builder.Services.AddSingleton<HeroesService>();
builder.Services.AddSingleton(new ContactsClient(DaprClient.CreateInvokeHttpClient("contactsapi")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
