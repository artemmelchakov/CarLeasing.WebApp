using AutoMapper;
using CarLeasing.Data;
using CarLeasing.Data.Models;
using CarLeasing.WebApp.Dto.Responses;
using CarLeasing.WebApp.Specifications;
using CarLeasing.WebApp.Specifications.ProviderSpecs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarLeasing.WebApp.Controllers.Api.V1;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProviderController : ControllerBase
{
    private readonly ILogger<ProviderController> _logger;
    private readonly ICarLeasingRepository _repository;
    private readonly IMapper _mapper;

    public ProviderController(ILogger<ProviderController> logger, ICarLeasingRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить список с информацией о 3-ёх самых популярных поставщиках, то есть о тех поставщиках, которые имеют наибольшее количество офферов.
    /// </summary>
    /// <returns> Список <see cref="ProviderGetPopularResponseDto"/> с информацией о 3-ёх самых популярных поставщиках. </returns>
    [HttpGet("popular")]
    public async Task<IEnumerable<ProviderGetPopularResponseDto>> GetPopularAsync()
    {
        var providers = await _repository.Find(new ProviderGetPopularSpec()).ToArrayAsync();
        var orderedproviders = providers.OrderByDescending(p => p.Offers == null ? 0 : p.Offers.Count()).Take(3);
        var response = _mapper.Map<IEnumerable<ProviderGetPopularResponseDto>>(orderedproviders);
        return response;
    }
}
