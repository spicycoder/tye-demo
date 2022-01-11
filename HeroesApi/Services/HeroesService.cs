using HeroesApi.Clients;
using Shared;

namespace HeroesApi.Services;

public class HeroesService
{
    private readonly ContactsClient _contactsClient;

    public HeroesService(ContactsClient contactsClient)
    {
        _contactsClient = contactsClient;
    }

    public Hero[] Heroes { get; } = new[]
    {
        new Hero
        {
            Id = "Spiderman",
            Name = "Peter Parker",
            Universe = "Marvel"
        },
        new Hero
        {
            Id = "Batman",
            Name = "Bruce Wayne",
            Universe = "DC"
        },
        new Hero
        {
            Id = "Ironman",
            Name = "Tony Stark",
            Universe = "Marvel"
        },
        new Hero
        {
            Id = "Superman",
            Name = "Clark Kent",
            Universe = "DC"
        }
    };

    public async Task<Hero?> FindHero(string id)
    {
        var hero = Heroes.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.CurrentCultureIgnoreCase));
        hero!.Contact = await _contactsClient.GetContactAsync(hero.Name);
        return hero;
    }
}