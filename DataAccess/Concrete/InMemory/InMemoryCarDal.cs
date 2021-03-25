using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 20000, Description = "Sedan Araç", ModelYear = 2008},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 35000, Description = "Hatchback Araç", ModelYear=2015},
                new Car{Id = 3, BrandId = 1,ColorId = 2, DailyPrice = 50000, Description = "Sedan Araç", ModelYear = 2014},
                new Car{Id = 4, BrandId = 2,ColorId = 2, DailyPrice = 80000, Description = "Hatchback Araç", ModelYear = 2018},
                new Car{Id = 5, BrandId = 1,ColorId = 2, DailyPrice = 32000, Description = "Sedan Araç", ModelYear = 2012},

            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);


        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
