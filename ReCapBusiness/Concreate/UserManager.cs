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
            try
            {
                _user.Add(user);
                return new SuccessResult(Messages.AddedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.AddedErrorMessage);
            }
        }

        public IResult Delete(User user)
        {
            try
            {
                _user.Delete(user);
                return new SuccessResult(Messages.DeletedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DeletedErrorMessage);
            }
        }

        public IDataResult<User> Get(int userId)
        {
            try
            { 
                return new SuccessDataResult<User>(_user.Get(p=> p.Id == userId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(Messages.ListedErrorMessage);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<User>>(_user.GetAll(),Messages.ListedMessage);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<User>>(Messages.ListedErrorMessage);
            }
        }

        public IResult Update(User user)
        {
            try
            {
                _user.Update(user);
                return new SuccessResult(Messages.UpdatedMessage);
            }
            catch (Exception)
            {           
                return new ErrorResult(Messages.UpdatedErrorMessage);
            }
        }
    }
}
