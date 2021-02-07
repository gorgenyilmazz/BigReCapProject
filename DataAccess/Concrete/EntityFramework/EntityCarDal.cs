using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EntityCarDal : ICarDal
    {
        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }

        List<Car> ICarDal.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
