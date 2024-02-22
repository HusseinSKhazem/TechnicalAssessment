using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Technical_Assesment.Data.Dto;
using Technical_Assesment.Interface;

namespace Technical_Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _Service;
        public CustomerController(ICustomerServices Service)
        {
            _Service = Service;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _Service.GetAllCustomers();
                if (response.IsNullOrEmpty())
                {
                    return NotFound("No Customers");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCustomers")]
        public async Task<IActionResult> AddCustomers(CustomerDto dto)
        {
            try
            {
                var response = await _Service.AddCustomer(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomers(CustomerDto dto)
        {
            try
            {
                var response = await _Service.updateCustomer(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCustomer(string email)
        {
            try
            {
                var response = await _Service.DeleteCustomer(email);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
