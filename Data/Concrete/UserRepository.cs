using Core.Data.Concrete;
using Data.Abstract;
using Data.Concrete.Contexts;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Data.Concrete
{
    public class UserRepository : EntityRepositoryBase<User, NorthwindContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                return (from oc in context.OperationClaimSet
                        join uoc in context.UserOperationClaimSet on oc.OperationClaimId equals uoc.OperationClaimId
                        where uoc.UserId == user.UserId
                        select new OperationClaim
                        {
                            OperationClaimId = oc.OperationClaimId,
                            Name = oc.Name
                        }).ToList();
            }
        }
    }
}
