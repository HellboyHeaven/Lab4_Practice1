using static System.Net.Mime.MediaTypeNames;

namespace FakeStoreApiClient.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{{\n\tId: {Id} \n\tUsername: {Username} \n\tEmail: {Email}\n\tPassword: {Password}\n}}";
    }
}
