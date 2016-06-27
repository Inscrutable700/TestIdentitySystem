using System;
using TIS.Business.Managers;
using TIS.Data;

namespace TIS.Business
{
    public class BusinessContext : IDisposable
    {
        private RepositoryContext repositoryContext;

        private UserManager userManager;

        public BusinessContext()
        {
            this.repositoryContext = new RepositoryContext();
        }

        public static BusinessContext Create()
        {
            return new BusinessContext();
        }

        public UserManager UserManager
        {
            get
            {
                if (this.userManager == null)
                {
                    this.userManager = new UserManager(this.repositoryContext, this);
                }

                return this.userManager;
            }
        }

        public void Dispose()
        {
            this.repositoryContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
