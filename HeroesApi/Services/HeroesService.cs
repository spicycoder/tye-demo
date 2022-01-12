using Dapr.Client;
using HeroesApi.Clients;
using Shared;
using Shared.Standards;

namespace HeroesApi.Services;

public class HeroesService
{
    private readonly ContactsClient _contactsClient;
    private readonly DaprClient _daprClient;

    public HeroesService(
        ContactsClient contactsClient,
        DaprClient daprClient)
    {
        _contactsClient = contactsClient;
        _daprClient = daprClient;
    }

    public Hero[] Heroes { get; } = new[]
    {
        new Hero
        {
            Id = "Spiderman",
            Universe = "Marvel"
        },
        new Hero
        {
            Id = "Batman",
            Universe = "DC"
        },
        new Hero
        {
            Id = "Ironman",
            Universe = "Marvel"
        },
        new Hero
        {
            Id = "Superman",
            Universe = "DC"
        }
    };

    public async Task<Hero?> FindHero(string id)
    {
        var identity = id.ToLower();

        var hero = Heroes.FirstOrDefault(x => string.Equals(x.Id, identity, StringComparison.CurrentCultureIgnoreCase));
        var heroes = await _daprClient.GetSecretAsync(Constants.SecretStore, identity);

        if (heroes.ContainsKey(identity))
        {
            hero!.Name = heroes[identity];
            hero!.Contact = await _contactsClient.GetContactAsync(hero.Name);
        }
        
        return hero;
    }
}