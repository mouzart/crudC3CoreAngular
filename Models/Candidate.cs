using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MouzartSamuelBacarinEasy.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }     
        public string Phone { get; set; }
        public string Linkedin { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Portfolio { get; set; }
        public WorkLoad WorkLoad { get; set; }
        public WorkSchedule WorkSchedule { get; set; }
        public List<CandidateKnowledge> CandidateKnowledges { get; set; }
    }
}
