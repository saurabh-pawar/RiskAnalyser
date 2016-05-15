using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;
using RiskAnalyser.Application.RiskRules;
using Xunit;

namespace RiskAnalyser.UnitTests
{
    public class CustomerRuleTests
    {
        [Fact]
        public void UnusualCustomerRule_ShouldTake_UnsualCustomerAsInput_ReturnTrue()
        {
            //Customer 1. Unusual Customer
            var sbet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                Win = 1
            };


            var ubet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                ToWin = 0
            };

            var sbets1 = new List<Bet>();
            sbets1.Add(sbet1);
            sbets1.Add(sbet1);
            var ubets1 = new List<Bet>();
            ubets1.Add(ubet1);
            var customer1 = new Customer { Id = 1, SettledBets = sbets1, UnSettledBets = ubets1 };


            var rule = new UnusualCustomerRule();

            Assert.True(rule.IsTrue(customer1));        
                   
        }

        [Fact]
        public void UnusualCustomerRule_ShouldTake_UsualCustomer_ReturnFalse()
        {

            //Customer 2. Usual Customer

            var sbet2 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 2,
                EventId = 1,
                Stake = 1,
                Win = 0
            };

            var ubet2 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 2,
                EventId = 1,
                Stake = 1,
                ToWin = 0
            };

            var sbets2 = new List<Bet>();
            sbets2.Add(sbet2);
            sbets2.Add(sbet2);
            var ubets2 = new List<Bet>();
            ubets2.Add(ubet2);

            var customer2 = new Customer { Id = 1, SettledBets = sbets2, UnSettledBets = ubets2 };


            var rule = new UnusualCustomerRule();

            Assert.False(rule.IsTrue(customer2));
        }
    }
}
