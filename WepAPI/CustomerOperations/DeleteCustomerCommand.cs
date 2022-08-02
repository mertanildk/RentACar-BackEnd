using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;

namespace WepAPI.CustomerOperations
{
    public class DeleteCustomerCommand
    {
        private readonly RentCarContext _rentCarContext;
       
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(RentCarContext rentCarContext)
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
            _rentCarContext.Customers.Remove(customer);
            _rentCarContext.SaveChanges();
        }


    }
}
