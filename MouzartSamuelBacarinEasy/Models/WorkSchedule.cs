using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouzartSamuelBacarinEasy.Models
{
    public class WorkSchedule
    {
        public int Id { get; set; }
        public Boolean Morning { get; set; }
        public Boolean Afternoon { get; set; }
        public Boolean Night { get; set; }
        public Boolean Dawn { get; set; }
        public Boolean Business { get; set; }
        public int HourlySalaryRequirement { get; set; }
        public int CandidateId { get; set; }
        [JsonIgnore]
        public Candidate Candidate { get; set; }
    }
}
