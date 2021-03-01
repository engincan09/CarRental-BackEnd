using ReCapProjectCore.DataAccess;
using ReCapProjectCore.Entities.Concrete;
using ReCapProjectCore.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
