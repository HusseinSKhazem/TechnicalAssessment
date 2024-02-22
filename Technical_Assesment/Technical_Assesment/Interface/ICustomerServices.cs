using Technical_Assesment.Data.Dto;
using Technical_Assesment.Data.Models;

namespace Technical_Assesment.Interface
{
    public interface ICustomerServices
    {
        Task<string> AddCustomer(CustomerDto dto);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<string> updateCustomer(CustomerDto dto);
        Task<string> DeleteCustomer(string email);
    }
}
