using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Linq;

namespace WepAPI.CustomerOperations
{
    public class CreateCustomerCommand
    {//bizim bir modele ihtiyacımız var çünkü dışarıdan setleyeceğiz çünkü kullanıcıdan geliyor. A0 Tr

        public CreateCustomerModel Model { get; set; } 

        private readonly RentCarContext _rentalCarContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(RentCarContext rentalCarContext, IMapper mapper)
        {
            _rentalCarContext = rentalCarContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _rentalCarContext.Customers.SingleOrDefault(x => x.CompanyName == Model.CompanyName);
            if (customer is not null)
            { throw new InvalidOperationException("Customer mevcut"); }


            customer = _mapper.Map<Customer>(Model);

            //customer.CompanyName = Model.CompanyName;
            //customer.UserId = Model.UserId;
            _rentalCarContext.Customers.Add(customer);
            _rentalCarContext.SaveChanges();
            

        }
        public class CreateCustomerModel 
        {
            public int UserId { get; set; }
            public string CompanyName { get; set; }
        }
    }
    
}
