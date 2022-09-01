using Exercicios.Data;
using Exercicios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Exercicios.Repositories
{
    public class BandaRepository : IBandaRepository
    {
        private readonly IDbContextFactory<M3S1DbContext> _dbContextFactory;

        public BandaRepository(IDbContextFactory<M3S1DbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Delete(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                BandaModel banda = context.Bandas.First(banda => banda.Id == id);
                context.Bandas.Remove(banda);
                context.SaveChanges();
            }
        }

        public IList<BandaModel> GetAll()
        {
            IList<BandaModel> bandas;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                bandas = context.Bandas.ToList();
            }

            return bandas;
        }

        public BandaModel GetById(int id)
        {
            BandaModel banda;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                banda = context.Bandas.FirstOrDefault(banda => banda.Id == id);
            }

            return banda;
        }

        public int Post(BandaModel model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Bandas.Add(model);
                context.SaveChanges();
            }

            return model.Id;
        }

        public int Put(BandaModel model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Bandas.Update(model);
                context.SaveChanges();
            }

            return model.Id;
        }

        public bool CheckBandEvent(BandaModel model)
        {
            bool isBandBusy;
            using (var context = _dbContextFactory.CreateDbContext())
            {
                isBandBusy = context.Eventos.Any(evento => evento.BandaId == model.Id);
            }

            return isBandBusy;
        }
    }
}
