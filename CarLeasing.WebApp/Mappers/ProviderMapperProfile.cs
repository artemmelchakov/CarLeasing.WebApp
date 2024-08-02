using AutoMapper;
using CarLeasing.Data.Models;
using CarLeasing.WebApp.Dto.Responses;

namespace CarLeasing.WebApp.Mappers;

/// <summary>
/// Профиль маппинга сущности <see cref="Provider"/>.
/// </summary>
public class ProviderMapperProfile : Profile
{
    public ProviderMapperProfile()
    {
        CreateMap<Provider, ProviderGetPopularResponseDto>()
            .ForMember(d => d.OffersCount, e => e.MapFrom(s => s.Offers == null ? 0 : s.Offers.Count()));
    }
}
