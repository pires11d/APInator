using Jarbas.Domain.Data;
using Jarbas.Domain.Entities;

namespace Jarbas.Domain.Repositories
{
    public class EmissionRepository : EntityRepository<Emission, APIContext>
    {
        public EmissionRepository(APIContext context) : base(context)
        {

        }
    }
}
