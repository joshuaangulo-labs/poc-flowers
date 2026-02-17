namespace Flowers.Core.Domain;

public class Schedule
{
    public Guid Id { get; init; }
    public Guid BenefactorId { get; set; }
    public Guid BeneficiaryId { get; set; }
    public Guid? GiftId { get; set; }
    public Guid? MessageId { get; set; }
    public Occasion Occasion { get; set; }
    public DateOnly NextDeliveryDate { get; set; }
    public bool IsRecurring { get; set; }
    public ScheduleStatus Status { get; set; }
    public DateTimeOffset CreatedAt { get; init; }

    public Benefactor Benefactor { get; set; } = null!;
    public Beneficiary Beneficiary { get; set; } = null!;
    public Gift? Gift { get; set; }
    public Message? Message { get; set; }
}

public enum Occasion
{
    Birthday,
    Anniversary,
    Holiday,
    Custom
}

public enum ScheduleStatus
{
    Active,
    Paused,
    Completed,
    Cancelled
}
