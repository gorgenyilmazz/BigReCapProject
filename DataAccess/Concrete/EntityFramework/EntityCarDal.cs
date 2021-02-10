using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EntityCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carToAdd = context.Entry(car);

                carToAdd.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Car car)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carToDelete = context.Entry(car);

                carToDelete.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public void Update(Car car)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carToUpdate = context.Entry(car);

                carToUpdate.State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext()) 
            {
                return filter == null ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
                    
            }
                
        }

       

       
    }
}
