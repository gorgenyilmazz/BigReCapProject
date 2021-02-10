using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapContext context = new ReCapContext()) 
            {
                var brandToAdd = context.Entry(entity);

                brandToAdd.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapContext context = new ReCapContext()) 
            {
                var brandToRemove = context.Entry(entity);

                brandToRemove.State = EntityState.Deleted;
                context.SaveChanges();

            }
               
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList(); 

            }
        }

        

       
    }
}
