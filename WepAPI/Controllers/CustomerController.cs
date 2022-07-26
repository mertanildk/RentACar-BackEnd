using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WepAPI.CustomerOperations;
using WepAPI.CustomersOperations;
using static WepAPI.CustomerOperations.CreateCustomerCommand;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly RentCarContext _rentCarContext;

       

        public CustomerController(ICustomerService customerService ,RentCarContext rentCarContext)
        {
            _customerService = customerService;
            _rentCarContext = rentCarContext;
        }
        [HttpPost("add")]
        public IActionResult Add(CreateCustomerModel createCustomerModel)
        {
            CreateCustomerCommand createCustomer = new CreateCustomerCommand(_rentCarContext);
            createCustomer.Model = createCustomerModel;
            createCustomer.Handle();
            return Ok();

            //var result = _customerService.Add(customer);
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            GetCustomersQuery query = new GetCustomersQuery(_rentCarContext);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _customerService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

