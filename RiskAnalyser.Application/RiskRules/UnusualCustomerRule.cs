using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application.RiskRules
{
    public class UnusualCustomerRule : ICustomerRule
    {
        public bool IsTrue(Customer customer)
        {
            var wins = 0;
            var totalGames = 0;

            foreach (var bet in customer.SettledBets)
            {
                if (bet.Win > 0)
                    wins++;

                totalGames++;
            }

            var winPercentage = Convert.ToDouble(wins) / Convert.ToDouble(totalGames) * 100.0;

            return winPercentage > 60.0;
        }
    }
}
