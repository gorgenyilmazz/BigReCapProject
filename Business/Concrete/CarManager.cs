using Business.Abstract;
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

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _cars.Add(car);
                Console.WriteLine(car.Description + "Eklendi");
            }
            else
                Console.WriteLine("Arabanin ismi minimum 2 karakter ve gunluk fiyati 0 dan buyuk olmalidir.");

               
        }

        public List<Car> GetAll()
        {
            return _cars.GetAll();
        }

        public List<Car> GetCarsByBranddId(int id)
        {
            return _cars.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _cars.GetAll(c => c.ColorId == id);
        }
        public List<CarDetailsDto> GetCarDetails()
        {
            return _cars.GetCarDetails();
        }

        public void Update(Car car)
        {
            _cars.Update(car);
            Console.WriteLine(car.Description + "Guncellenmis hali: " + car.Description);
        }

        public void Delete(Car car)
        {
            _cars.Delete(car);
            Console.WriteLine(car.Description + "Silindi");
        }

        public List<Car> GetById(int id)
        {
            return _cars.GetAll(c=>c.Id == id);
        }
    }
}
