namespace Flowers.Core.Domain;

public class Benefactor
{
    public Guid Id { get; init; }
    public string UserId { get; set; } = string.Empty;   // Descope user ID
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; init; }

    public ICollection<Beneficiary> Beneficiaries { get; set; } = [];
    public ICollection<Gift> Gifts { get; set; } = [];
    public ICollection<Schedule> Schedules { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];
}
