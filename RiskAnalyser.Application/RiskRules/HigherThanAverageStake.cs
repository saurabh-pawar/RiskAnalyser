using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application.RiskRules
{
    public class HigherThanAverageStake : IBetRule<int>
    {
        public List<Bet> IdentifyBets(Customer customer, int identifier)
        {
            var totalBets = 0;
            var totalStake = 0;
            foreach (var settledBet in customer.SettledBets)
            {
                totalStake += settledBet.Stake;
                totalBets += 1;
            }

            var customerAverage = Convert.ToDouble(totalStake)/Convert.ToDouble(totalBets);

            var customerAverageToCompare = customerAverage * Convert.ToDouble(identifier);

            return customer.UnSettledBets.Where(unSettledBet => Convert.ToDouble(unSettledBet.Stake) > customerAverageToCompare).ToList();
        }
    }
}
