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
    public class EntityColorDal : IColorDal
    {
        public void Add(Color color)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var colorToAdd = context.Entry(color);

                colorToAdd.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Color color)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var colorToDelete = context.Entry(color);

                colorToDelete.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public void Update(Color color)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var colorToModify = context.Entry(color);

                colorToModify.State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();

            }
        }

       
    }
}
