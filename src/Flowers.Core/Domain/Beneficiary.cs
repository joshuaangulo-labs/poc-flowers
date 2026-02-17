namespace Flowers.Core.Domain;

public class Beneficiary
{
    public Guid Id { get; init; }
    public Guid BenefactorId { get; set; }
    public string UserId { get; set; } = string.Empty;   // Descope user ID (set when beneficiary claims account)
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Relationship { get; set; }             // e.g. spouse, child, friend
    public DateOnly? DateOfBirth { get; set; }
    public bool IsOptedOut { get; set; }
    public DateTimeOffset CreatedAt { get; init; }

    public Benefactor Benefactor { get; set; } = null!;
    public ICollection<Schedule> Schedules { get; set; } = [];
}
