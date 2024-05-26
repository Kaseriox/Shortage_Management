using System.Text.Json.Serialization;

namespace Data.Model.User;

[JsonDerivedType(typeof(User), "user")]
[JsonDerivedType(typeof(Admin), "admin")]
public record User
{
    public required Guid Id { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}