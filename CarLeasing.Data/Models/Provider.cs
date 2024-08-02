using CarLeasing.Data.Models.Base;
using CarLeasing.Data.Models.Interfaces;

namespace CarLeasing.Data.Models;

/// <summary>
/// Модель сущности "Поставщик".
/// </summary>
public class Provider : Entity, IHavingIdEntity
{
    /// <summary>
    /// Id сущности.
    /// </summary>
    public virtual uint Id { get; set; }
    /// <summary>
    /// Наименование.
    /// </summary>
    public virtual string Name { get; set; } = null!;
    /// <summary>
    /// Дата создания.
    /// </summary>
    public virtual DateTime CreationDate { get; set; }
    /// <summary>
    /// Офферы данного поставщика.
    /// </summary>
    public virtual IEnumerable<Offer>? Offers { get; set; }
}
