using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalyser.Application.Models;

namespace RiskAnalyser.Application.Repositories
{
    public class CsvCustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers(string settledDataSource, string unSettledDataSource)
        {
            Dictionary<int, Customer> customerDictionary = new Dictionary<int, Customer>();

            var dataSources = new string[2] { settledDataSource, unSettledDataSource };

            for (int i = 0; i < 2; i++)
            {
                var reader = new StreamReader(File.OpenRead(dataSources[i]));

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var id = Convert.ToInt32(values[0]);
                    var bet = new Bet
                    {
                        CustomerId = Convert.ToInt32(values[0]),
                        EventId = Convert.ToInt32(values[1]),
                        ParticipantId = Convert.ToInt32(values[2]),
                        Stake = Convert.ToInt32(values[3]),
                    };


                    if (!customerDictionary.ContainsKey(id))
                    {
                        customerDictionary.Add(id, new Customer
                        {
                            Id = id,
                            SettledBets = new List<Bet>(),
                            UnSettledBets = new List<Bet>()
                        });
                    }

                    if (i == 0)
                    {
                        bet.Win = Convert.ToInt32(values[4]);
                        customerDictionary[id].SettledBets.Add(bet);
                    }
                    else
                    {
                        bet.ToWin = Convert.ToInt32(values[4]);
                        customerDictionary[id].UnSettledBets.Add(bet);
                    }

                }

                reader.Dispose();

            }

            return customerDictionary.Values.ToList();
        }
    }
}
