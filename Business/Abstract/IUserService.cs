using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        User Add(User user);
        User GetByMail(string email);
    }
}
