using Microsoft.AspNetCore.Mvc;
using RealPOSApi.Controllers;
using RealPOSApi.DTO;
using RealPOSApi.Model;
using RealPOSApi.Repositories;


[ApiController]
[Route("api/[controller]")]
public class CustomerController : BaseController<CustomerController>
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    public CustomerController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
    // GET: api/GetAllCustomers
    [HttpGet("GetAllCustomers", Name = "GetAllCustomers")]
    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _repositoryWrapper.Customer.GetAllCustomers();
    }
    // POST: api/SaveCustomer
    [HttpPost("SaveCustomer", Name = "SaveCustomer")]
    public async Task<CustomerRespondDTO> AddCategory(CustomerDTO param)
    {
        try
        {
            if (!await _repositoryWrapper.Customer.CheckDuplicate(param.url))
            {
                int Maxid = await _repositoryWrapper.Customer.MaxCategoryID();
                Customer newobj = new Customer
                {
                    customer_id = Maxid,
                    name = param.Name,
                    url = param.url
                };
                await _repositoryWrapper.Customer.Create(newobj);
                return new CustomerRespondDTO { Message = "Customer Save Successfully" };
            }
            else
            {
                return new CustomerRespondDTO { Message = "Customer Already Exist" };
            }
        }
        catch (Exception ex)
        {
            return new CustomerRespondDTO { Message = "Error in SaveCustomer", Error = "Error in SaveCustomer" };
        }
    }
    // POST: api/UpdateCustomer
    [HttpPost("UpdateCustomer", Name = "UpdateCustomer")]
    public async Task<CustomerRespondDTO> UpdateCustomer(UpdateCustomerRequestDTO param)
    {
        try
        {
            Customer? OldCustomer = await _repositoryWrapper.Customer.OldCustomer(param.CustomerID);
            if (OldCustomer == null)
            {
                return new CustomerRespondDTO { Message = "Customer does not exist" };
            }
            else
            {
                OldCustomer.name = param.Name;
                OldCustomer.url = param.url;
                await _repositoryWrapper.Category.Update(OldCustomer);
                return new CustomerRespondDTO { Message = "Customer update successfull" };
            }
        }
        catch (Exception ex)
        {
            return new CustomerRespondDTO { Message = "Error in UpdateCustomer", Error = "Error in UpdateCustomer" };
        }
    }
    // POST: api/DeleteCategory/1
    [HttpPost("DeleteCustomer/{customerid}", Name = "DeleteCustomer")]
    public async Task<CustomerRespondDTO> DeleteCustomer(int customerid)
    {
        try
        {
            Customer? OldCustomer = await _repositoryWrapper.Customer.OldCustomer(customerid);
            if (OldCustomer == null)
            {
                return new CustomerRespondDTO { Message = "Customer does not exist" };
            }
            else
            {
                await _repositoryWrapper.Customer.Delete(OldCustomer);
                return new CustomerRespondDTO { Message = "Customer delete successfull" };
            }
        }
        catch (Exception ex)
        {
            return new CustomerRespondDTO { Message = "Error in DeleteCustomer", Error = "Error in DeleteCustomer" };
        }
    }
}