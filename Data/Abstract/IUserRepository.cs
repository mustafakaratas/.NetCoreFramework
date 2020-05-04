using Core.Data.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Data.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
