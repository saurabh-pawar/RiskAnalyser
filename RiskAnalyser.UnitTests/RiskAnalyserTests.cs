using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using RiskAnalyser.Application.Models;
using RiskAnalyser.Application.Repositories;
using Xunit;

namespace RiskAnalyser.UnitTests
{
    public class RiskAnalyserTests
    {
        [Fact]
        public void Call_GetUnusualCustomers_Returns_ListOfCustomers()
        {
            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var customers = sut.GetUnusualCustomers(It.IsAny<List<Customer>>());

            Assert.True(typeof(List<Customer>) == customers.GetType());
        }

        [Fact]
        public void Call_GetUnSettledBetsFromUnusualCustomers_Returns_ListOfBets()
        {
            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var bets = sut.GetUnSettledBetsFromUnusualCustomers(It.IsAny<List<Customer>>());

            Assert.True(typeof(List<Bet>) == bets.GetType());
        }

        [Fact]
        public void Call_GetHigherStakeBets_Returns_ListOfBets()
        {
            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var bets = sut.GetHigherStakeBets(It.IsAny<List<Customer>>(),It.IsAny<int>());

            Assert.True(typeof(List<Bet>) == bets.GetType());
        }

        [Fact]
        public void Call_GetBigWinBets_Returns_ListOfCustomers()
        {
            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var bets = sut.GetBigWinBets(It.IsAny<List<Customer>>(),It.IsAny<int>());

            Assert.True(typeof(List<Bet>) == bets.GetType());
        }

    }
}
