using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Technical_Assesment.Data;
using Technical_Assesment.Data.Dto;
using Technical_Assesment.Data.Models;
using Technical_Assesment.Interface;

namespace Technical_Assesment.Repository
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _Context;
        public CustomerServices(ApplicationDbContext Context)
        {
             _Context = Context;
        }
        public async Task<string> AddCustomer(CustomerDto dto)
        {
            try
            {
                var existingCustomer = await _Context.Customers.Where(c => c.Email == dto.Email).FirstOrDefaultAsync();
                if (existingCustomer != null) { return ($"User with {dto.Email} already exists"); }
                var Cstmr = new Customer
                {
                    IdentityPhoto = dto.IdentityPhoto,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Gender = dto.Gender,
                    PhoneNumber = dto.PhoneNumber,
                    Country = dto.Country,
                };
                await _Context.Customers.AddAsync(Cstmr);
                await _Context.SaveChangesAsync();
                return ("User Add Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> DeleteCustomer(string email)
        {
            try
            {
                var existingCustomer = await _Context.Customers.Where(c => c.Email == email).FirstOrDefaultAsync();
                if (existingCustomer == null) { return ("User wasn't found"); }
                _Context.Customers.Remove(existingCustomer);
                await _Context.SaveChangesAsync();
                return ("Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                var Cstmrs = await _Context.Customers.ToListAsync();
                return Cstmrs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> updateCustomer(CustomerDto dto)
        {
            try
            {
                var existingCustomer = await _Context.Customers.Where(c => c.Email == dto.Email).FirstOrDefaultAsync();
                if (existingCustomer == null)
                {
                    return ("User not found");
                }
                existingCustomer.Email = dto.Email;
                existingCustomer.FirstName = dto.FirstName;
                existingCustomer.LastName = dto.LastName;
                existingCustomer.PhoneNumber = dto.PhoneNumber;
                existingCustomer.IdentityPhoto = dto.IdentityPhoto;
                existingCustomer.Gender = dto.Gender;
                existingCustomer.Country = dto.Country;
                existingCustomer.DateOfBirth = dto.DateOfBirth;

                await _Context.SaveChangesAsync();
                return ("Updated Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
