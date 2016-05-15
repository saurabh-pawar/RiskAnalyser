using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application
{
    public class RiskAnalyser : IRiskAnalyser
    {
        public List<Customer> GetUnusualCustomers(List<Customer> customers)
        {
            return null;
        }

        public List<Bet> GetUnSettledBetsFromUnusualCustomers(List<Customer> customers)
        {
            return null;
        }

        public List<Bet> GetHigherStakeBets(List<Customer> customers, int stakeRate)
        {
            return null;
        }

        public List<Bet> GetBigWinBets(List<Customer> customers, int winMargin)
        {
            return null;
        }
    }
}
