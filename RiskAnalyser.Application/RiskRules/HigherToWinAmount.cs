using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application.RiskRules
{
    public class HigherToWinAmount : IBetRule<int>
    {
        public List<Bet> IdentifyBets(Customer customer, int identifier)
        {
            return customer.UnSettledBets.Where(unSettledBet => unSettledBet.ToWin > identifier).ToList();
        }
    }
}
