using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorNameExists(color.Name));
            if (result!=null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);

        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorNameExists(color.Name));
            if (result != null)
            {
                return result;
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(co=>co.Id==colorId));
        }

        private IResult CheckIfColorNameExists(string colorName)
        {
            var result = _colorDal.GetAll(c => c.Name==colorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ColorNameExistsError);
            }

            return new SuccessResult();
        }
    }
}
