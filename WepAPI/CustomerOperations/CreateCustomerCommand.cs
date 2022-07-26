using DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;

namespace WepAPI.CustomerOperations
{
    public class CreateCustomerCommand
    {//bizim bir modele ihtiyacımız var çünkü dışarıdan setleyeceğiz çünkü kullanıcıdan geliyor. A0 Tr

        public CreateCustomerModel Model { get; set; } 

        private readonly RentCarContext _rentalCarContext;

        public CreateCustomerCommand(RentCarContext rentalCarContext)
        {
            _rentalCarContext = rentalCarContext;
        }

        public void Handle()
        {
            var customer = _rentalCarContext.Customers.SingleOrDefault(x => x.CompanyName == Model.CompanyName);
            if (customer is not null)
            { throw new InvalidOperationException("Customer mevcut"); }
                

            customer = new Entity.Concrete.Customer();
            customer.CompanyName = Model.CompanyName;
            customer.UserId = Model.UserId;
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
