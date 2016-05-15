using System.Collections.Generic;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}