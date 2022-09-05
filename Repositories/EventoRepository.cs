using Exercicios.Data;
using Exercicios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Exercicios.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IDbContextFactory<M3S1DbContext> _dbContextFactory;

        public EventoRepository(IDbContextFactory<M3S1DbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Delete(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                EventoModel evento = context.Eventos.FirstOrDefault(evento => evento.Id == id);

                context.Eventos.Remove(evento);
                context.SaveChanges();
            }
        }

        public IList<EventoModel> GetAll()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Eventos.ToList();
            }
        }

        public EventoModel GetById(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Eventos.FirstOrDefault(evento => evento.Id == id);
            }
        }

        public int Post(EventoModel model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Eventos.Add(model);
                return model.Id;
            }
        }

        public int Put(EventoModel model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Eventos.Update(model);
                context.SaveChanges();
                
                return model.Id;
            }
        }

        void IRepository<EventoModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
