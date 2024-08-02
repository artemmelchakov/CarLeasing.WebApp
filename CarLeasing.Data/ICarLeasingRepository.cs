using CarLeasing.Data.Models.Base;

namespace CarLeasing.Data;

/// <summary>
/// Интерфейс общего репозитория для приложения CarLeasing.
/// </summary>
public interface ICarLeasingRepository
{
    /// <summary> 
    /// Получить сущность из БД. 
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    Task<TEntity?> GetAsync<TEntity>(uint id) where TEntity : Entity;

    /// <summary> 
    /// Получить сущность по указанной спецификации. 
    /// </summary>
    /// <param name="specification"> Спецификация, описывающая поиск и преобразование сущности. </param>
    Task<TResult?> GetAsync<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : Entity;

    /// <summary> 
    /// Получить сущности <typeparamref name="TEntity"/> из БД. 
    /// </summary>
    IQueryable<TEntity> Find<TEntity>() where TEntity : Entity;

    /// <summary> 
    /// Получить сущности по спецификации. 
    /// </summary>
    /// <param name="specification">Спецификация.</param>
    IQueryable<TResult> Find<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : Entity;

    /// <summary> 
    /// Добавить сущность в контекст. 
    /// </summary>
    /// <param name="entity"> Добавляемая сущность. </param>
    Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : Entity;

    /// <summary>
    /// Добавить множество сущностей в контекст.
    /// </summary>
    /// <param name="entities"> Добавляемые сущности. </param>
    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity;

    /// <summary> 
    /// Зарегистрировать изменения сущности в контексте. 
    /// </summary>
    /// <param name="entity"> Изменяемая сущность. </param>
    void Update<TEntity>(TEntity entity) where TEntity : Entity;

    /// <summary> 
    /// Удалить сущность из контекста. 
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    Task DeleteAsync<TEntity>(uint id) where TEntity : Entity;

    /// <summary> 
    /// Асинхронно сохраняет все изменения, сделанные в этом контексте, в БД. 
    /// </summary>
    /// <returns> Количество сущностей, записанных в БД. </returns>
    Task<int> SaveChangesAsync();
}
