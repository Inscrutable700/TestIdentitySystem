using System;
using TIS.Data.Repositories;

namespace TIS.Data
{
    public class RepositoryContext : IDisposable
    {
        private DataContext dataContext;

        private UserRepository userRepository;

        public RepositoryContext()
        {
            this.dataContext = new DataContext();
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.dataContext);
                }

                return this.userRepository;
            }
        }

        public void Dispose()
        {
            this.dataContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
