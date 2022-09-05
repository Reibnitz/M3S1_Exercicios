using AutoMapper;
using Exercicios.Data.Dtos;
using Exercicios.Data.Dtos.Evento;
using Exercicios.Models;
using Exercicios.Repositories;

namespace Exercicios.Services
{
    public class EventoService
    {
        private readonly IEventoRepository _repository;
        private IMapper _mapper;

        public EventoService(IEventoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IList<ReadEventoDto> Get()
        {
            IList<EventoModel> eventosList = _repository.GetAll();

            return _mapper.Map<IList<ReadEventoDto>>(eventosList);
        }

        public ReadEventoDto GetById(int id)
        {
            EventoModel? model = _repository.GetById(id);

            if (model == null)
                return null;

            return _mapper.Map<ReadEventoDto>(model);
        }

        public ReadEventoDto Post(CreateEventoDto eventoDto)
        {
            EventoModel model = _mapper.Map<EventoModel>(eventoDto);
            _repository.Post(model);

            return _mapper.Map<ReadEventoDto>(model);
        }

        public bool Put(int id, UpdateEventoDto eventoDto)
        {
            EventoModel? evento = _repository.GetById(id);

            if (evento == null)
                return false;

            _mapper.Map(eventoDto, evento);
            _repository.Put(evento);

            return true;
        }

        public bool Delete(int id)
        {
            EventoModel? evento = _repository.GetById(id);

            if (evento == null)
                return false;

            _repository.Delete(evento.Id);
            return false;
        }
    }
}
