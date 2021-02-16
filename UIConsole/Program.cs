using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Text;

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
            //ColorCRUDTest();
            //UserCreate();
            //CustomerCreate();

        }

        private static void CustomerCreate()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var customer = new Customer()
            {
                UserId = 1,
                CompanyName = "Kocaeli Uni"
            };

            customerManager.Add(customer);
        }

        private static void UserCreate()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var user = new User()
            {
                FirstName = "gorgen",
                LastName = "Yilmaz",
                Email = "myemail@hotmail.com",
                Password = "password123"
            };
            Console.WriteLine(userManager.Add(user));
        }

        private static void ColorCRUDTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
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
            CarManager carManager = new CarManager(new EfCarDal());
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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
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
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "//" + car.BrandName + "//" + car.ColorName + "//" + car.DailyPrice);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();

            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest() 
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }
       
    }
}
