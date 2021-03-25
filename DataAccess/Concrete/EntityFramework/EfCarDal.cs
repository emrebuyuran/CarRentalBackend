using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, RentACarContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.Id equals b.Id
                    join co in context.Colors
                        on c.ColorId equals co.Id
                    select new CarDetailDto
                        {BrandName = b.Name, CarName = c.Name, ColorName = co.Name, DailyPrice = c.DailyPrice};
                return result.ToList();
            }
        }
    }
}
