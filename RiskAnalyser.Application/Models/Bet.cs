using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskAnalyser.Application.Models
{
    public class Bet
    {
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public int Stake { get; set; }
        public int ToWin { get; set; }
        public int Win { get; set; }

    }
}
