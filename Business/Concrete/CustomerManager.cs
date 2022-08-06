using Business.Abstract;
using Business.Constants.Messages;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            var result = BusinessRules.Run(ChechCustomerIdExist(customer.Id));
            if (result!=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult(Messages.operationSuccessfully);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<Customer> Get(int id)
        {

            return new SuccessDataResult<Customer>(_customerDal.Get(x=>x.Id==id));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
        private IResult ChechCustomerIdExist(int customerId)
        {
            var result = _customerDal.Get(c => c.Id== customerId);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
