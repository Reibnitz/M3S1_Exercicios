using AutoMapper;
using Exercicios.Data.Dtos;
using Exercicios.Models;

namespace Exercicios.Profiles
{
    public class BandaProfile : Profile
    {
        public BandaProfile()
        {
            CreateMap<BandaModel, ReadBandaDto>();
            CreateMap<CreateBandaDto, BandaModel>();
            CreateMap<UpdateBandaDto, BandaModel>();
        }
    }
}
