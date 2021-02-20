using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concreate;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concreate
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

        public IResult Update(User user)
        {
            _user.Update(user);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}
