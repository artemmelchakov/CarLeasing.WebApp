namespace CarLeasing.WebApp.Dto.Requests;

/// <summary>
/// Dto запроса для создания сущности "Оффер".
/// </summary>
public class OfferAddRequestDto
{
    /// <summary>
    /// Марка.
    /// </summary>
    public string Brand { get; set; } = null!;
    /// <summary>
    /// Модель.
    /// </summary>
    public string Model { get; set; } = null!;
    /// <summary>
    /// Id поставщика.
    /// </summary>
    public uint ProviderId { get; set; }
}
