using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine(color.ColorName + "Eklendi");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine(color.ColorName + "Silindi");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();

        }

        public List<Color> GetColorsByColordId(int id)
        {
            return _colorDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine(color.ColorName + "Guncellenmis hali : " + color.ColorName);
        }
    }
}
