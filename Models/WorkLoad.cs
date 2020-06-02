using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouzartSamuelBacarinEasy.Models
{
    public class WorkLoad
    {
        public int Id { get; set; }
        public Boolean PerDayUpTo4 { get; set; }
        public Boolean PerDay4To6 { get; set; }
        public Boolean PerDay6To8 { get; set; }
        public Boolean PerDayUpTo8 { get; set; }
        public Boolean OnlyWeeKend { get; set; }
        public int CandidateId { get; set; }
        [JsonIgnore]
        public Candidate Candidate { get; set; }
    }
}
