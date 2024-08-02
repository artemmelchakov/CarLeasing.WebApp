using CarLeasing.Data.Models.Base;
using CarLeasing.Data.Models.Interfaces;

namespace CarLeasing.Data.Models;

/// <summary>
/// Модель сущности "Оффер".
/// </summary>
public class Offer : Entity, IHavingIdEntity
{
    /// <summary>
    /// Id сущности.
    /// </summary>
    public virtual uint Id { get; set; }
    /// <summary>
    /// Марка.
    /// </summary>
    public virtual string Brand { get; set; } = null!;
    /// <summary>
    /// Модель.
    /// </summary>
    public virtual string Model { get; set; } = null!;
    /// <summary>
    /// Поставщик.
    /// </summary>
    public virtual Provider Provider { get; set; } = null!;
    /// <summary>
    /// Id поставщика.
    /// </summary>
    public virtual uint ProviderId { get; set; }
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public virtual DateTime RegistrationDate { get; set; }
}
