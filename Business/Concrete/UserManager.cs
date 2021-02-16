using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(true, Messages.EntityAdded);

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(true, Messages.EntityDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), true, Messages.EntitiesListed);

        }

        public IDataResult<List<User>> GetUserById(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == id), true, Messages.EntitiesListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(true, Messages.EntityUpdated);
        }
    }
}
