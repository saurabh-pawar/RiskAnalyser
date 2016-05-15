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
    public class BetsRuleTests
    {

        [Fact]
        public void HigherThanAverageStakeBy10_Rule_ShouldTakeCustomer_ReturnValidBets()
        {
            //Customer 1. Unusual Customer
            var sbet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                Win = 9
            };


            var ubet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 100,
                ToWin = 1000
            };

            var ubet2 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                ToWin = 90
            };

            var sbets1 = new List<Bet>();
            sbets1.Add(sbet1);
            var ubets1 = new List<Bet>();
            ubets1.Add(ubet1);
            ubets1.Add(ubet2);
            var customer1 = new Customer { Id = 1, SettledBets = sbets1, UnSettledBets = ubets1 };


            var rule = new HigherThanAverageStake();

            var rate = 10;

            var avgToCompare = (sbet1.Stake / 1)* rate;

            var identifiedBets = rule.IdentifyBets(customer1, rate);
            Assert.IsType<List<Bet>>(identifiedBets);

            foreach (var bet in identifiedBets)
            {
                Assert.True(bet.Stake > avgToCompare);
            }
        }

        [Fact]
        public void HigherThanAverageStakeBy30_Rule_ShouldTakeCustomer_ReturnValidBets()
        {
            //Customer 1. Unusual Customer
            var sbet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                Win = 9
            };


            var ubet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 280,
                ToWin = 1000
            };

            var ubet2 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                ToWin = 90
            };

            var sbets1 = new List<Bet>();
            sbets1.Add(sbet1);
            var ubets1 = new List<Bet>();
            ubets1.Add(ubet1);
            ubets1.Add(ubet2);
            var customer1 = new Customer { Id = 1, SettledBets = sbets1, UnSettledBets = ubets1 };


            var rule = new HigherThanAverageStake();

            var rate = 30;

            var avgToCompare = (sbet1.Stake / 1) * rate;

            var identifiedBets = rule.IdentifyBets(customer1, rate);
            Assert.IsType<List<Bet>>(identifiedBets);

            foreach (var bet in identifiedBets)
            {
                Assert.True(bet.Stake > avgToCompare);
            }
        }


        [Fact]
        public void HigherToWin_Rule_ShouldTakeCustomer_ReturnBetsWithMoreThan1000ToWin()
        {
            //Customer 1. Unusual Customer
            var sbet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                Win = 9
            };


            var ubet1 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 280,
                ToWin = 1001
            };

            var ubet2 = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                ToWin = 90
            };

            var sbets1 = new List<Bet>();
            sbets1.Add(sbet1);
            var ubets1 = new List<Bet>();
            ubets1.Add(ubet1);
            ubets1.Add(ubet2);
            var customer1 = new Customer { Id = 1, SettledBets = sbets1, UnSettledBets = ubets1 };


            var rule = new HigherThanAverageStake();

            var rate = 1000;

            var identifiedBets = rule.IdentifyBets(customer1, rate);

            Assert.IsType<List<Bet>>(identifiedBets);

            foreach (var bet in identifiedBets)
            {
                Assert.True(bet.ToWin > rate);
            }
        }
    }
}
