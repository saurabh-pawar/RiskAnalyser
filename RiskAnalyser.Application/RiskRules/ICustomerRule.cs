using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application.RiskRules
{
    public interface ICustomerRule
    {
        bool IsTrue(Customer customer);
    }
}
