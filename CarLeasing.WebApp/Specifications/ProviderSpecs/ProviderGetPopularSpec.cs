using AutoMapper;
using CarLeasing.Data;
using CarLeasing.Data.Models;
using CarLeasing.WebApp.Dto.Responses;
using Microsoft.EntityFrameworkCore;

namespace CarLeasing.WebApp.Specifications.ProviderSpecs;

/// <summary>
/// Спецификация, которая получает список с информацией о 3-ёх самых популярных поставщиках.
/// </summary>
public class ProviderGetPopularSpec : ISpecification<Provider, Provider>
{
    /// <summary>
    /// <inheritdoc cref="ProviderGetPopularSpec"/>
    /// </summary>
    public ProviderGetPopularSpec()
    {
    }
    public IQueryable<Provider> AppendQuery(IQueryable<Provider> entities) => entities.Include(p => p.Offers).AsNoTracking();
}
