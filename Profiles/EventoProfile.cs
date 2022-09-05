using AutoMapper;
using Exercicios.Data.Dtos.Evento;
using Exercicios.Models;

namespace Exercicios.Profiles
{
    public class EventoProfile : Profile
    {
        public EventoProfile()
        {
            CreateMap<CreateEventoDto, EventoModel>();
            CreateMap<UpdateEventoDto, EventoModel>();
            CreateMap<EventoModel, ReadEventoDto>();

        }
    }
}
