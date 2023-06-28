using AutoMapper;
using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Learning.Domain.Services;
using BackEnd_SocialE.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_SocialE.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EventController {
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public EventController(IEventService eventService, IMapper mapper) {
        _eventService = eventService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<EventResource>> GetAllAsync() {
        var events = await _eventService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
        return resources;
    }
}