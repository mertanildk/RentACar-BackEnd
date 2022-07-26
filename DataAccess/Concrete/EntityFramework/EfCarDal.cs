using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<RentCarContext, Car>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ModelName = c.ModelName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ColorId = c.ColorId,
                                 ModelYear = c.ModelYear
                             };

                return result.ToList();
            }

        }
    }
}
