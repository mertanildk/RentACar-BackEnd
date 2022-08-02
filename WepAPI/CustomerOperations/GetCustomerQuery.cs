
using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using WepAPI.Common;

namespace WepAPI.CustomersOperations

{
    public class GetCustomerQuery
    {
        private readonly RentCarContext _rentCarContext;
        private readonly IMapper _mapper;
        public int UserId { get; set; }
        public GetCustomerQuery(RentCarContext rentCarContext, IMapper mapper)
        {
            _rentCarContext = rentCarContext;
            _mapper = mapper;
        }
        public CustomerViewModel Handle()
        {
            var customer = _rentCarContext.Customers.Where(c => c.Id == UserId).SingleOrDefault();
            if (customer is null)
            {
                throw new InvalidOperationException("customer is not exist");
            }
            CustomerViewModel customerViewModel = _mapper.Map<CustomerViewModel>(customer);
            return customerViewModel;
        }
        public class CustomerViewModel
        {
            public string UserName { get; set; }
            public string CompanyName { get; set; }
        }
    }
}
