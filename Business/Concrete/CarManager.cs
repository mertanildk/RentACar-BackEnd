using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IBrandService _brandService;
        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.add")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(ChechCarIdExist(car.Id));
            if (result!=null)
            {
                return new ErrorResult();
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.addedEntity);
        }

        [PerformanceAspect(0.0001)]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [PerformanceAspect(0.0001)]
        [CacheAspect]
        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id));
        }

        [CacheAspect]
        [PerformanceAspect(0.0001)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
       
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == id));
        }

        [PerformanceAspect(0.0001)]
        public IResult Update(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        private IResult ChechCarIdExist(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);
            if (result!=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
