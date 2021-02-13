using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarDetailsTest();

            //BrandCRUDTest();
            //CarCRUDTest();
            ColorCRUDTest();


        }

        private static void ColorCRUDTest()
        {
            ColorManager colorManager = new ColorManager(new EntityColorDal());
            Color colorAddandDelete = new Color() {ColorName="EklenenRenk" };

            Console.WriteLine("Eklemeden once \n");
            ColorTest();

            colorManager.Add(colorAddandDelete);
            Console.WriteLine("Ekledikten Sonra \n");
            ColorTest();

            colorManager.Delete(colorAddandDelete);
            Console.WriteLine("Sildikten sonra \n");
            ColorTest();
            
            Color colorUpdated = new Color() {ColorId=1, ColorName = "GuncelenenRenk" };
            colorManager.Update(colorUpdated);

            Console.WriteLine("Guncellendikten sonra \n");
            ColorTest();



        }

        private static void CarCRUDTest()
        {
            CarManager carManager = new CarManager(new EntityCarDal());
            Car carAddandDelete = new Car();

            carAddandDelete.Description = "it will be added and deleted";
            Console.WriteLine("Eklemeden Once \n");
            CarTest();
            Console.WriteLine("\n");

            carManager.Add(carAddandDelete);
            Console.WriteLine("Ekledikten Sonra \n");
            CarTest();
            Console.WriteLine("\n");

            //carManager.Delete(carAddandDelete);
            // Console.WriteLine("Silindikten sonra");
            //CarTest();
            Car carToUpdate = new Car() { Id = 2, Description = "Updated:Skoda", BrandId=2, ColorId=1 };
            carManager.Update(carToUpdate);
            Console.WriteLine("Guncellendikten sonra");
            CarTest();

            
        }

        private static void BrandCRUDTest()
        {
            BrandManager brandManager = new BrandManager(new EntityBrandDal());
            Brand brandAddandDelete = new Brand();

            brandAddandDelete.BrandName = "Hyundai";
            Console.WriteLine("Eklemeden Once \n");
            BrandTest();

            brandManager.Add(brandAddandDelete);
            Console.WriteLine("Ekledikten Sonra \n");
            BrandTest();
            Console.WriteLine("\n");

            brandManager.Delete(brandAddandDelete);
            Console.WriteLine("Silindikten sonra\n");
            BrandTest();
            Console.WriteLine("\n");

            Brand brandToUpdate = new Brand() {BrandId=2, BrandName="Skoda" };
            brandManager.Update(brandToUpdate);
            BrandTest();
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EntityCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "//" + car.BrandName + "//" + car.ColorName + "//" + car.DailyPrice);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EntityCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EntityBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest() 
        {
            ColorManager colorManager = new ColorManager(new EntityColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }
    }
}
