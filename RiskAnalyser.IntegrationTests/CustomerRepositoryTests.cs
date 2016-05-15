using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Repositories;
using Xunit;

namespace RiskAnalyser.IntegrationTests
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void CsvCustomerRepository_TakesDataSourceAsString_ReturnsListOfCustomers()
        {
            ICustomerRepository custRepo = new CsvCustomerRepository();

            var customers = custRepo.GetAllCustomers("BetData/Settled.csv", "BetData/Unsettled.csv");
            
            //There are 6 customers in the test data sheets
            Assert.True(customers.Count == 6);
        }

        [Fact]
        public void CsvCustomerRepository_TakesDataSourceAsString_ReturnsListOfCustomers_FirstCustomerHasGivenBets()
        {
            ICustomerRepository custRepo = new CsvCustomerRepository();

            var customers = custRepo.GetAllCustomers("BetData/Settled.csv", "BetData/Unsettled.csv");

            //There are 6 customers in the test data sheets
            Assert.True(customers.Count == 6);

            //In our Test Data sheets first customer has 10 settled bets and 4 unsettled bets
            Assert.True(customers[0].SettledBets.Count == 10);
            Assert.True(customers[0].UnSettledBets.Count == 4);
        }

    }
}
