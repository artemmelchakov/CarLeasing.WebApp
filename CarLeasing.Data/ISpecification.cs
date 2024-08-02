using CarLeasing.Data.Models.Base;

namespace CarLeasing.Data;

/// <summary>
/// Спецификация, описывающая поиск и преобразование сущностей из контекста.
/// </summary>
/// <typeparam name="TEntity"> Тип сущности. </typeparam>
/// <typeparam name="TResult"> Результирующий тип. </typeparam>
public interface ISpecification<TEntity, TResult> where TEntity : Entity
{
    IQueryable<TResult> AppendQuery(IQueryable<TEntity> entities);
}