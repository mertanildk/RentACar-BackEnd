using AutoMapper;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WepAPI.CustomerOperations.CreateCustomerCommand;
using static WepAPI.CustomerOperations.GetCustomersQuery;
using static WepAPI.CustomerOperations.UpdateCustomerCommand;
using static WepAPI.CustomersOperations.GetCustomerQuery;

namespace WepAPI.Common
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerModel, Customer>();//createCustomerModel, Customer'a maplenebilir olsun.
            CreateMap<UpdateCustomerModel, Customer>();
            CreateMap<Customer, CustomerViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => ((UserEnum)src.UserId).ToString()));
            CreateMap<Customer, CustomersViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => ((UserEnum)src.UserId).ToString()));
        }
    }
}
