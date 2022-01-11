using System.Text.Json;
using Shared;

namespace HeroesApi.Clients;

public class ContactsClient
{
    private readonly HttpClient _httpClient;

    public ContactsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Contact?> GetContactAsync(string name)
    {
        var contact = await _httpClient.GetFromJsonAsync<Contact>(
            $"/Contacts/contact?name={name}",
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        return contact;
    }
}