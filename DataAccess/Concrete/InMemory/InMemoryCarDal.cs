using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=10, ColorId=20, DailyPrice=200, Description="Toyota", ModelYear=2017 },
                new Car{Id=2, BrandId=20, ColorId=30, DailyPrice=150, Description="Hyundai", ModelYear=2017 },
                new Car{Id=3, BrandId=30, ColorId=40, DailyPrice=550, Description="Mercedes", ModelYear=2019 },
                new Car{Id=4, BrandId=50, ColorId=60, DailyPrice=400, Description="Audi", ModelYear=2018 },
                new Car{Id=5, BrandId=70, ColorId=80, DailyPrice=380, Description="BMW", ModelYear=2015 }

            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);

            
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
            
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
