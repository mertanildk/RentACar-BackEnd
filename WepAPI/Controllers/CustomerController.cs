using AutoMapper;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WepAPI.CustomerOperations;
using WepAPI.CustomersOperations;
using static WepAPI.CustomerOperations.CreateCustomerCommand;
using static WepAPI.CustomerOperations.UpdateCustomerCommand;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly RentCarContext _rentCarContext;
        private readonly IMapper _mapper;



        public CustomerController(ICustomerService customerService, RentCarContext rentCarContext, IMapper mapper)
        {
            _customerService = customerService;
            _rentCarContext = rentCarContext;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public IActionResult Add(CreateCustomerModel createCustomerModel)
        {
            CreateCustomerCommand createCustomer = new CreateCustomerCommand(_rentCarContext, _mapper);
            try
            {
                createCustomer.Model = createCustomerModel;
                CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
                validator.ValidateAndThrow(createCustomer);
                createCustomer.Handle();

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
            //if (!result.IsValid)
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        System.Console.WriteLine();
            //        return BadRequest("Property " + item.PropertyName + " Error Message : " + item.ErrorMessage);


            //    }
            //    return BadRequest("olmadı");
            //}
            //else
            //{
            //    createCustomer.Handle();
            //    return Ok();

            //}

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
            GetCustomersQuery query = new GetCustomersQuery(_rentCarContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {

            GetCustomerQuery query = new GetCustomerQuery(_rentCarContext, _mapper);
            query.UserId = id;
            var result = query.Handle();
            return Ok(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)//bu tamam
        {
            try
            {
                DeleteCustomerCommand command = new DeleteCustomerCommand(_rentCarContext);
                command.CustomerId = id;
                DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult Update(int id, UpdateCustomerModel updateCustomerModel)//bunu yapamadım 
        {
            try
            {
                UpdateCustomerCommand command = new UpdateCustomerCommand(_rentCarContext);
                command.CustomerId = id;
                command.Model = updateCustomerModel;
                command.Handle();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}

