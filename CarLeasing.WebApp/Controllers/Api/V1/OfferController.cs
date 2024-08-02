using AutoMapper;
using CarLeasing.Data;
using CarLeasing.Data.Models;
using CarLeasing.WebApp.Dto.Requests;
using CarLeasing.WebApp.Dto.Responses;
using CarLeasing.WebApp.Specifications.OfferSpecs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarLeasing.WebApp.Controllers.Api.V1;

[ApiController]
[Route("/api/v1/[controller]")]
public class OfferController : ControllerBase
{
    private readonly ILogger<OfferController> _logger;
    private readonly ICarLeasingRepository _repository;
    private readonly IMapper _mapper;

    public OfferController(ILogger<OfferController> logger, ICarLeasingRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Создать оффер.
    /// </summary>
    /// <param name="dto"><inheritdoc cref="OfferAddRequestDto"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task AddAsync(OfferAddRequestDto dto)
    {
        var offer = _mapper.Map<Offer>(dto);
        await _repository.AddAsync(offer);
        await _repository.SaveChangesAsync();
    }

    /// <summary>
    /// Получить список с информацией об офферах. Ответ отфильтрован по по строке поиска <paramref name="search"/>, 
    /// офферы фильтруются по полям "Марка", "Модель", "Наименование поставщика".
    /// </summary>
    /// <param name="search"> Значение строки поиска. </param>
    /// <returns> <see cref="OfferGetListResponseDto"/> </returns>
    [HttpGet("list")]
    public async Task<OfferGetListResponseDto> GetListAsync(string search)
    {
        var offers = await _repository.Find(new OfferGetListSpec(search, _mapper)).ToArrayAsync();
        return new OfferGetListResponseDto { Count = offers.Length, Offers = offers };
    }
}
