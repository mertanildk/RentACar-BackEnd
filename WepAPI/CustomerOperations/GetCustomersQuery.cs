using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace WepAPI.CustomerOperations
{
    public class GetCustomersQuery
    {
        private readonly RentCarContext _rentCarContext;
        private readonly IMapper _mapper;
        public GetCustomersQuery(RentCarContext rentCarContext, IMapper mapper)
        {
            _rentCarContext = rentCarContext;
            _mapper = mapper;
        }
        public List<CustomersViewModel> Handle()
        {
            var CustomersList = _rentCarContext.Customers.OrderBy(x => x.Id).ToList<Customer>();
            List<CustomersViewModel> customers = _mapper.Map<List<CustomersViewModel>>(CustomersList);

            return customers;
        }

        public class CustomersViewModel
        {
            public string UserName { get; set; }
            public string CompanyName { get; set; }
        }

    }
}
