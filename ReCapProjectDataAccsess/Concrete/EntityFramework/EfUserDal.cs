using ReCapProjectCore.DataAccess.EntityFramework;
using ReCapProjectCore.Entities.Concrete;
using ReCapProjectDataAccsess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ReCapProjectEntities.DTOs;

namespace ReCapProjectDataAccsess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserAndOperationDto GetUserAndClaim(string email)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from user in context.Users
                             join userOperationClaim in context.UserOperationClaims
                             on user.Id equals userOperationClaim.UserId
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             join customer in context.Customers
                             on user.Id equals customer.UserId
                             where user.Email == email
                             select new UserAndOperationDto { 
                                 UserId = user.Id, 
                                 FirstName = user.FirstName, 
                                 LastName = user.LastName, 
                                 Email = user.Email, 
                                 ClaimName = operationClaim.Name,
                                 CompanyName = customer.CompanyName,
                                 FindeksPoint = customer.FindeksPoint};
                return result.FirstOrDefault();
            }
        
        }

        
       
    }
}
