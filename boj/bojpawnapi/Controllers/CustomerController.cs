using Microsoft.AspNetCore.Mvc;
using bojpawnapi.Service;
using bojpawnapi.DTO;

namespace bojpawnapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;

        }
        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customerList = await _customerService.GetCustomersAsync();
            if (customerList != null)
            {
                return Ok(customerList);
            }
            else
            {
                return NoContent();
            }
        }
        //GET by id
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> PostCustomer(CustomerDTO customer)
        {
            var result = await _customerService.AddCustomerAsync(customer);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetCustomer), new { id = result.CustomerId }, result);
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDTO customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            var result = await _customerService.UpdateCustomerAsync(customer);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }

}