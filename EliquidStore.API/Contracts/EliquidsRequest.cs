namespace EliquidStore.API.Contracts;

public record EliquidsRequest(
    string Name,
    string Flavor,
    int Capacity);