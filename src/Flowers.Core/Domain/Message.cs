namespace Flowers.Core.Domain;

public class Message
{
    public Guid Id { get; init; }
    public Guid BenefactorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string? MediaUrl { get; set; }                 // Optional photo or video
    public DateTimeOffset CreatedAt { get; init; }

    public Benefactor Benefactor { get; set; } = null!;
}
