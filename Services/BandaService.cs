using AutoMapper;
using Exercicios.Data.Dtos;
using Exercicios.Models;
using Exercicios.Repositories;

namespace Exercicios.Services
{
    public class BandaService
    {
        private readonly IBandaRepository _repository;
        private IMapper _mapper;

        public BandaService(IBandaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IList<ReadBandaDto> Get()
        {
            IList<BandaModel> bandasList = _repository.GetAll();

            return _mapper.Map<IList<ReadBandaDto>>(bandasList);
        }

        public ReadBandaDto GetById(int id)
        {
            BandaModel? model = _repository.GetById(id);

            if (model == null)
                return null;

            return _mapper.Map<ReadBandaDto>(model);
        }

        public ReadBandaDto Post(CreateBandaDto bandaDto)
        {
            BandaModel model = _mapper.Map<BandaModel>(bandaDto);
            _repository.Post(model);

            return _mapper.Map<ReadBandaDto>(model);
        }

        public bool Put(int id, UpdateBandaDto bandaDto)
        {
            BandaModel? banda = _repository.GetById(id);

            if (banda == null)
                return false;

            _mapper.Map(bandaDto, banda);
            _repository.Put(banda);

            return true;
        }

        public bool Delete(int id)
        {
            BandaModel? banda = _repository.GetById(id);
            bool isBandBusy = _repository.CheckBandEvent(banda);

            if (isBandBusy == true || banda == null)
                return false;

            _repository.Delete(banda.Id);
            return false;
        }
    }
}
