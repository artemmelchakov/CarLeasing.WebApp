using AutoMapper;
using CarLeasing.Data;
using CarLeasing.Data.Models;
using CarLeasing.WebApp.Dto.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarLeasing.WebApp.Specifications.OfferSpecs;

/// <summary>
/// Спецификация, которая получает список с информацией об офферах, 
/// фильтруя офферы по строке поиска по полям "Марка", "Модель", "Наименование поставщика".
/// Если строка поиска пустая - выдаст все офферы.
/// </summary>
public class OfferGetListSpec : ISpecification<Offer, OfferGetListResponseDtoOffer>
{
    private readonly string? _search;
    private readonly IMapper _mapper;

    /// <summary>
    /// <inheritdoc cref="OfferGetListSpec"/>
    /// </summary>
    /// <param name="search"> Строка поиска, по которой производится фильтрафия. </param>
    /// <param name="mapper"> Объект маппера. </param>
    public OfferGetListSpec(string? search, IMapper mapper)
    {
        _search = search;
        _mapper = mapper;
    }
    public IQueryable<OfferGetListResponseDtoOffer> AppendQuery(IQueryable<Offer> entities) =>
        _search.IsNullOrEmpty() 
            ? entities.Include(e => e.Provider).Select(e => _mapper.Map<OfferGetListResponseDtoOffer>(e)).AsNoTracking()
            : entities
                .Include(e => e.Provider)
                .Where(e => e.Brand.Contains(_search!) || e.Model.Contains(_search!) || e.Provider.Name.Contains(_search!))
                .Select(e => _mapper.Map<OfferGetListResponseDtoOffer>(e))
                .AsNoTracking();
}
