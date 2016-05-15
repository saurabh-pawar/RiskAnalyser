using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;
using RiskAnalyser.Application.RiskRules;

namespace RiskAnalyser.Application
{
    public class RiskAnalyser : IRiskAnalyser
    {
        public List<Customer> GetUnusualCustomers(List<Customer> customers)
        {
            ICustomerRule rule = new UnusualCustomerRule();

            var unusalCustomers = new List<Customer>();
            foreach (var customer in customers)
            {
                if (rule.IsTrue(customer))
                {
                    unusalCustomers.Add(customer);
                }
            }
            return unusalCustomers;
        }

        public List<Bet> GetUnSettledBetsFromUnusualCustomers(List<Customer> customers)
        {
            var riskyBets = new List<Bet>();
            return null;
        }

        public List<Bet> GetHigherStakeBets(List<Customer> customers, int stakeRate)
        {
            var riskyBets = new List<Bet>();
            return null;
        }

        public List<Bet> GetBigWinBets(List<Customer> customers, int winMargin)
        {
            var riskyBets = new List<Bet>();
            return null;
        }
    }
}
