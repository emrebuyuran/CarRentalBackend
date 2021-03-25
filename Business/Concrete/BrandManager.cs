using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            var result = CheckIfBrandNameExists(brand.Name);
            if (result!=null)
            {
                return result;
            }
            _brandDal.Add(brand);
           return new SuccessResult(Messages.BrandAdded); 
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            var result = CheckIfBrandNameExists(brand.Name);
            if (result!= null)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
            
        }
        [ValidationAspect(typeof(BrandValidator))]
        private IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(b => b.Name == brandName).Any();
            if (!result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExistsError);
            }
            return new SuccessResult();
        }
    }
}
