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
                return new SuccessResult(true, Messages.EntityAdded);
            }
            else
                return new ErrorResult(false, "Arabanin ismi minimum 2 karakter ve gunluk fiyati 0 dan buyuk olmalidir.");

               
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(), true);
        }

        public IDataResult<List<Car>> GetCarsByBranddId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(c => c.BrandId == id), true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(c => c.ColorId == id), true);
        }
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_cars.GetCarDetails(), true);
        }

        public IResult Update(Car car)
        {
            _cars.Update(car);
            return new SuccessResult(true, Messages.EntityUpdated);
        }

        public IResult Delete(Car car)
        {
            _cars.Delete(car);
            return new SuccessResult(true, Messages.EntityDeleted);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(c=>c.Id == id), true);
        }
    }
}
