using CarLeasing.Data.Models;

namespace CarLeasing.WebApp.Dto.Responses;

/// <summary>
/// Dto ответа для получения списка самых популярных поставщиков.
/// </summary>
public class ProviderGetPopularResponseDto
{
    /// <summary>
    /// Id сущности.
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// Количество офферов данного поставщика.
    /// </summary>
    public int OffersCount { get; set; }
}
