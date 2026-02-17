namespace Flowers.Core.Domain;

public class Gift
{
    public Guid Id { get; init; }
    public Guid BenefactorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? VendorSku { get; set; }                // Catalog reference (FTD, 1-800-Flowers, etc.)
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public DateTimeOffset CreatedAt { get; init; }

    public Benefactor Benefactor { get; set; } = null!;
}
