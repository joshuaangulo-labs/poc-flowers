# Flowers — Domain Model

## Entities

### Benefactor
A user who pre-funds and schedules gifts for their loved ones. Created when a user signs up with the `benefactor` role.

| Property | Type | Notes |
|---|---|---|
| Id | Guid | |
| UserId | string | Descope user ID |
| FirstName, LastName | string | |
| Email | string | |
| CreatedAt | DateTimeOffset | |

### Beneficiary
A loved one added by a benefactor to receive gifts. May or may not have their own account.

| Property | Type | Notes |
|---|---|---|
| Id | Guid | |
| BenefactorId | Guid | Owning benefactor |
| UserId | string | Descope user ID — set when beneficiary claims an account |
| FirstName, LastName | string | |
| Email | string | |
| Phone | string? | |
| Relationship | string? | e.g. spouse, child, friend |
| DateOfBirth | DateOnly? | Used to calculate birthday schedules |
| IsOptedOut | bool | Beneficiary can opt out of future deliveries |
| CreatedAt | DateTimeOffset | |

### Gift
A gift item selected by a benefactor, optionally sourced from a vendor catalog.

| Property | Type | Notes |
|---|---|---|
| Id | Guid | |
| BenefactorId | Guid | |
| Name | string | |
| Description | string? | |
| VendorSku | string? | Catalog reference (FTD, 1-800-Flowers, etc.) |
| Price | decimal | |
| ImageUrl | string? | |
| CreatedAt | DateTimeOffset | |

### Message
A personal note composed by a benefactor, optionally attached to a scheduled delivery.

| Property | Type | Notes |
|---|---|---|
| Id | Guid | |
| BenefactorId | Guid | |
| Title | string | Internal label for the benefactor |
| Body | string | The message content |
| MediaUrl | string? | Optional photo or video |
| CreatedAt | DateTimeOffset | |

### Schedule
Defines when and how a gift is delivered to a beneficiary. Ties together a beneficiary, gift, and message for a specific occasion.

| Property | Type | Notes |
|---|---|---|
| Id | Guid | |
| BenefactorId | Guid | |
| BeneficiaryId | Guid | |
| GiftId | Guid? | Optional — may be assigned later |
| MessageId | Guid? | Optional — may be assigned later |
| Occasion | Occasion | Birthday, Anniversary, Holiday, Custom |
| NextDeliveryDate | DateOnly | |
| IsRecurring | bool | Whether to repeat each year |
| Status | ScheduleStatus | Active, Paused, Completed, Cancelled |
| CreatedAt | DateTimeOffset | |

## Relationships

```
Benefactor ──< Beneficiary
Benefactor ──< Gift
Benefactor ──< Message
Benefactor ──< Schedule
Beneficiary ──< Schedule
Schedule >── Gift (optional)
Schedule >── Message (optional)
```

## Enums

**Occasion** — the event type that triggers a delivery
- `Birthday`
- `Anniversary`
- `Holiday`
- `Custom`

**ScheduleStatus** — the current state of a schedule
- `Active` — will be processed on next delivery date
- `Paused` — skipped until resumed
- `Completed` — all deliveries fulfilled
- `Cancelled` — permanently stopped
