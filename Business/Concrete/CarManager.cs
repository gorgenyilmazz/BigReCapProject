using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cars;
        public CarManager(ICarDal carDal)
        {
            _cars = carDal;     
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _cars.Add(car);
                return new SuccessResult(Messages.EntityAdded);
            }
            else
                return new ErrorResult("Arabanin ismi minimum 2 karakter ve gunluk fiyati 0 dan buyuk olmalidir.");

               
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBranddId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(c => c.ColorId == id));
        }
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_cars.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _cars.Update(car);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult Delete(Car car)
        {
            _cars.Delete(car);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(c=>c.Id == id));
        }
    }
}
