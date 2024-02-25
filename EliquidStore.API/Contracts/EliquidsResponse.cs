namespace EliquidStore.API.Contracts;

public record EliquidsResponse(
    Guid Id,
    string Name,
    string Flavor,
    int Capacity);