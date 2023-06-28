using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Learning.Domain.Repositories;
using BackEnd_SocialE.Learning.Domain.Services;
using BackEnd_SocialE.Learning.Domain.Services.Communication;

namespace BackEnd_SocialE.Learning.Services;

public class EventService : IEventService
{
    //
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork) {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Event>> ListAsync() {
        return await _eventRepository.ListAsync();
    }

    public async Task<EventResponse> SaveAsync(Event _event) {
        try {
            await _eventRepository.AddAsync(_event);
            await _unitOfWork.CompleteAsync();
            return new EventResponse(_event);
        }
        catch (Exception e) {
            return new EventResponse($"Ocurrió un error mientras se guardaba el evento: {e.Message}");
        }
    }

    public async Task<EventResponse> UpdateAsync(int id, Event _event) {
        var exists = await _eventRepository.FindByIdAsync(id);
        if (exists == null) {
            return new EventResponse("No se encontró el evento");
        }

        exists.Name = _event.Name;
        try {
            _eventRepository.Update(exists);
            await _unitOfWork.CompleteAsync();
            return new EventResponse(exists);
        }
        catch (Exception e) {
            return new EventResponse($"Ocurrió un error mientras se actualizaba el evento: {e.Message}");
        }
    }

    public async Task<EventResponse> DeleteAsync(int id) {
        var exists = await _eventRepository.FindByIdAsync(id);
        if (exists == null) {
            return new EventResponse("No se encontró el evento");
        }

        try {
            _eventRepository.Remove(exists);
            await _unitOfWork.CompleteAsync();
            return new EventResponse(exists);
        }
        catch (Exception e) {
            return new EventResponse($"Ocurrió un error mientras se eliminaba el evento: {e.Message}");
        }
    }
}