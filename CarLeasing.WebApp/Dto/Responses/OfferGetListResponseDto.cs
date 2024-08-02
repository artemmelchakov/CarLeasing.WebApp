namespace CarLeasing.WebApp.Dto.Responses;

/// <summary>
/// Dto ответа для получения списка офферов.
/// </summary>
public class OfferGetListResponseDto
{
    /// <summary>
    /// Количество офферов в данном ответе.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Список с информацией об офферах.
    /// </summary>
    public IEnumerable<OfferGetListResponseDtoOffer>? Offers { get; set; }
}

/// <summary>
/// Элемент Dto <see cref="OfferGetListResponseDto"/>, представляющий собой информацию об оффере.
/// </summary>
public class OfferGetListResponseDtoOffer
{
    /// <summary>
    /// Id оффера.
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Марка.
    /// </summary>
    public string Brand { get; set; } = null!;
    /// <summary>
    /// Модель.
    /// </summary>
    public string Model { get; set; } = null!;
    /// <summary>
    /// Наименование поставщика.
    /// </summary>
    public string ProviderName { get; set; } = null!;
    /// <summary>
    /// Id поставщика.
    /// </summary>
    public uint ProviderId { get; set; }
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; set; }
}