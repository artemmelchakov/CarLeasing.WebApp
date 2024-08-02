using AutoMapper;
using CarLeasing.Data.Models;
using CarLeasing.WebApp.Dto.Requests;
using CarLeasing.WebApp.Dto.Responses;

namespace CarLeasing.WebApp.Mappers;

/// <summary>
/// Профиль маппинга сущности <see cref="Offer"/>.
/// </summary>
public class OfferMapperProfile : Profile
{
    public OfferMapperProfile()
    {
        CreateMap<Offer, OfferGetListResponseDtoOffer>()
            .ForMember(d => d.ProviderName, e => e.MapFrom(s => s.Provider.Name));

        CreateMap<OfferAddRequestDto, Offer>()
            .ForMember(d => d.RegistrationDate, e => e.MapFrom(s => DateTime.UtcNow));
    }
}
