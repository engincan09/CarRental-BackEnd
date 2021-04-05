using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.BusinessAspect.Autofac;
using ReCapProjectBusiness.Constants;
using ReCapProjectBusiness.ValidationRules.FluentValidation;
using ReCapProjectCore.Aspects.Autofac.Validation;
using ReCapProjectCore.Entities.Concrete;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;
using ReCapProjectCore.Utilities.Security.Hashing;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _user;

        public UserManager(IUserDal user)
        {
            _user = user;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _user.Add(user);
            return new SuccessResult(Messages.AddedMessage);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _user.Delete(user);
            return new SuccessResult(Messages.DeletedMessage);
        }

        public IDataResult<User> Get(int userId)
        {
            return new SuccessDataResult<User>(_user.Get(p => p.Id == userId));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_user.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_user.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_user.GetClaims(user));
        }

        public IDataResult<UserAndOperationDto> GetUserAndClaim(string email)
        {
            return new SuccessDataResult<UserAndOperationDto>(_user.GetUserAndClaim(email));
        }

      

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var updateUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = user.Status
            };
            _user.Update(updateUser);
            return new SuccessResult(Messages.UpdatedMessage);
        }

    }
}
