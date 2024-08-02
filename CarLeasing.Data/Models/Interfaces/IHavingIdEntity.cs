namespace CarLeasing.Data.Models.Interfaces;

/// <summary>
/// Сущности, имеющие идентификатор.
/// </summary>
public interface IHavingIdEntity
{
    /// <summary>
    /// Id сущности.
    /// </summary>
    public uint Id { get; set; }
}
