namespace TIS.Data.Repositories
{
    public abstract class RepositoryBase<TEntity>
    {
        protected DataContext dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public abstract TEntity Add(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract TEntity[] List();
        public abstract TEntity Get(int id);
    }
}
