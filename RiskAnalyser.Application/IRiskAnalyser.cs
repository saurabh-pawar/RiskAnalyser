using System.Collections.Generic;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application
{
    public interface IRiskAnalyser
    {
        List<Customer> GetUnusualCustomers(List<Customer> customers);

        List<Bet> GetUnSettledBetsFromUnusualCustomers(List<Customer> customers);

        List<Bet> GetHigherStakeBets(List<Customer> customers, int stakeRate);

        List<Bet> GetBigWinBets(List<Customer> customers, int winMargin);

    }
}