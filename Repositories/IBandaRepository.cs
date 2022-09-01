using Exercicios.Models;

namespace Exercicios.Repositories
{
    public interface IBandaRepository : IRepository<BandaModel>
    {
        bool CheckBandEvent(BandaModel model);
    }
}