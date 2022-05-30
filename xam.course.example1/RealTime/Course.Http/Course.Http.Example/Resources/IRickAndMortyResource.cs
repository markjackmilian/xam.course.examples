using Refit;

namespace Course.Http.Example.Resources;

public interface IRickAndMortyResource
{
    [Get("/character/{id}")]
    Task<RickResponse> GetCharacter(int id);

    // [Post("/character")]
    // Task AddUser(RickResponse user);

    // [Get("character/")]
    // Task<RickResponse[]> GetCharacters();
}