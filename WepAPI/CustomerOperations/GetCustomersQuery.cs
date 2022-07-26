using Business.Common;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace WepAPI.CustomersOperations

{
    public class GetCustomersQuery
    {
        private readonly RentCarContext _rentCarContext;

        public GetCustomersQuery(RentCarContext rentCarContext)
        {
            _rentCarContext = rentCarContext;
        }
        public List<CustomerViewModel> Handle()
        {
            var customerList = _rentCarContext.Customers.OrderBy(x => x.Id).ToList<Customer>();
            List<CustomerViewModel> customerViewModels= new List<CustomerViewModel>();
            foreach (var customer in customerList)
            {
                customerViewModels.Add(new CustomerViewModel()
                {
                    CompanyName = customer.CompanyName,
                    UserName = ((UserEnum)customer.UserId).ToString(),

                }) ;
            }
            return customerViewModels;
        }
        public class CustomerViewModel
        {
            public string UserName { get; set; }
            public string CompanyName { get; set; }
        }
    }
}
