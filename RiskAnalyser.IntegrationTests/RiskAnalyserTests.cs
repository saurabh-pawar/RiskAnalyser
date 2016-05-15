using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;
using Xunit;

namespace RiskAnalyser.IntegrationTests
{
    public class RiskAnalyserTests
    {
        [Fact]
        public void WhenCustomersArePassed_To_GetUnusualCustomerMethod_ShouldReturn_UnsualCustomers()
        {
            var sbet = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                Win = 1
            };

            var ubet = new Bet
            {
                ParticipantId = 1,
                CustomerId = 1,
                EventId = 1,
                Stake = 1,
                ToWin = 0
            };

            var sbets = new List<Bet>();
            sbets.Add(sbet);

            var ubets = new List<Bet>();
            ubets.Add(ubet);

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, SettledBets = sbets, UnSettledBets = ubets });

            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var unusualCustomers = sut.GetUnusualCustomers(customers);

            foreach (var unusualCustomer in unusualCustomers)
            {
                var winningBets = Convert.ToDouble(unusualCustomer.SettledBets.Select(b => (b.Win > 0)).Count());
                var totalBets = Convert.ToDouble(unusualCustomer.SettledBets.Count);
                var winPercent = winningBets / totalBets * 100.0;
                Assert.True(winPercent > 60.0);
            }
        }

        [Fact]
        public void WhenCustomersPassed_To_GetUnsettledBetsFromUnsualCustomers_ShouldReturnBetsFromUnusualCustomers()
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

            List<Customer> customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var riskyBets = sut.GetUnSettledBetsFromUnusualCustomers(customers);
            foreach (var riskyBet in riskyBets)
            {
                //In this test case, only customer id 1 is unusual customer.
                Assert.True(riskyBet.CustomerId == 1);
            }

        }

        [Fact]
        public void WhenCustomersPassed_To_GetHigherStakeBets_ShouldReturnBetsWhereStakeIs_10TimesHigher()
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
                Stake = 100,
                ToWin = 0
            };

            var sbets1 = new List<Bet>();
            sbets1.Add(sbet1);
            sbets1.Add(sbet1);
            var ubets1 = new List<Bet>();
            ubets1.Add(ubet1);
            var customer1 = new Customer { Id = 1, SettledBets = sbets1, UnSettledBets = ubets1 };


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

            List<Customer> customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var stakeRate = 10;

            var riskyBets = sut.GetHigherStakeBets(customers, stakeRate);

            foreach (var riskyBet in riskyBets)
            {
                //In this test case, only customer id 1 is unusual customer.
                Assert.True(riskyBet.CustomerId == 1);
            }

        }

        [Fact]
        public void WhenCustomersPassed_To_GetHigherStakeBets_ShouldReturnBetsWhereStakeIs_30TimesHigher()
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
                Stake = 30,
                ToWin = 0
            };

            var sbets1 = new List<Bet>();
            sbets1.Add(sbet1);
            sbets1.Add(sbet1);
            var ubets1 = new List<Bet>();
            ubets1.Add(ubet1);
            var customer1 = new Customer { Id = 1, SettledBets = sbets1, UnSettledBets = ubets1 };


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

            List<Customer> customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var stakeRate = 30;

            var riskyBets = sut.GetHigherStakeBets(customers, stakeRate);

            foreach (var riskyBet in riskyBets)
            {
                //In this test case, only customer id 1 is unusual customer.
                Assert.True(riskyBet.CustomerId == 1);
            }

        }

        [Fact]
        public void WhenCustomersPassed_To_GetBigWinBets_ShouldReturnBetsWhereWinIs_MoreThan1000()
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
                Stake = 30,
                ToWin = 0
            };

            var sbets1 = new List<Bet>();
            sbets1.Add(sbet1);
            sbets1.Add(sbet1);
            var ubets1 = new List<Bet>();
            ubets1.Add(ubet1);
            var customer1 = new Customer { Id = 1, SettledBets = sbets1, UnSettledBets = ubets1 };


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
                ToWin = 1000
            };

            var sbets2 = new List<Bet>();
            sbets2.Add(sbet2);
            sbets2.Add(sbet2);
            var ubets2 = new List<Bet>();
            ubets2.Add(ubet2);
            var customer2 = new Customer { Id = 1, SettledBets = sbets2, UnSettledBets = ubets2 };

            List<Customer> customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            Application.RiskAnalyser sut = new Application.RiskAnalyser();

            var winMargin = 1000;

            var riskyBets = sut.GetBigWinBets(customers, winMargin);

            foreach (var riskyBet in riskyBets)
            {
                //In this test case, only customer id 1 is unusual customer.
                Assert.True(riskyBet.CustomerId == 2);
            }

        }

    }
}
