namespace Exercicios.Repositories
{
    public interface IRepository<TModel>
    {
        TModel GetById(int id);
        IList<TModel> GetAll();
        int Post(TModel model);
        int Put(TModel model);
        void Delete(int id);
    }
}
