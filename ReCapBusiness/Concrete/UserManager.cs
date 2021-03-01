using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectCore.Entities.Concrete;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;
using ReCapProjectDataAccsess.Abstract;
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

        public IResult Add(User user)
        {
            _user.Add(user);
            return new SuccessResult(Messages.AddedMessage);
        }

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

        public IResult Update(User user)
        {
            _user.Update(user);
            return new SuccessResult(Messages.UpdatedMessage);
        }


    }
}
