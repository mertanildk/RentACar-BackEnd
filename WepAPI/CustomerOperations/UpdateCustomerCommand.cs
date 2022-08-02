using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Linq;

namespace WepAPI.CustomerOperations
{
    public class UpdateCustomerCommand
    {
        private readonly RentCarContext _rentCarContext;
        public UpdateCustomerModel Model { get; set; }
        public int CustomerId { get; set; }

        public UpdateCustomerCommand(RentCarContext rentCarContext)
        {
            _rentCarContext = rentCarContext;
            
        }
        public void Handle()
        {
            var customer = _rentCarContext.Customers.SingleOrDefault(c => c.Id == CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Customer is not exist");
            }
            customer.CompanyName=Model.CompanyName;
            customer.UserId=Model.UserId;
            _rentCarContext.Customers.Update(customer);
            _rentCarContext.SaveChanges();
        }
        public class UpdateCustomerModel
        {
            public int UserId { get; set; }
            public string CompanyName { get; set; }
        }

    }
}
