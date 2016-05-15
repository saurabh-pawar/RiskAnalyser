using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskAnalyser.Application.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public List<Bet> SettledBets { get; set; }
        public List<Bet> UnSettledBets { get; set; }
    }
}
