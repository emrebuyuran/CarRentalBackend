using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarsByColorId(int colorId);
        IDataResult<Car> GetCarsByBrandId(int brandId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();

    }
}
