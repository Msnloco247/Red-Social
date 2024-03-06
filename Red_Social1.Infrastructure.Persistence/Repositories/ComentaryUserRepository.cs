using Red_Social1.Core.Application.Interfaces.Repositories;
using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Entities;
using Red_Social1.Infrastructure.Identity.Interfaces.Repositories;
using Red_Social1.Infrastructure.Persistence.Context;
using Red_Social1.Infrastructure.Persistence.Contexts;
using Red_Social1.Infrastructure.Persistence.Repository;

namespace Red_Social1.Infrastructure.Persistence.Repository
{
    public class ComentaryUserRepository : GenericRepository<ComentaryUser>, IComentaryUserRepository
    {
        private readonly IdentityContext _dbContext;

        public ComentaryUserRepository(IdentityContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
