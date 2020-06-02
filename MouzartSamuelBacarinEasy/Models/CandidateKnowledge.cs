using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MouzartSamuelBacarinEasy.Models
{
    public class CandidateKnowledge
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        [JsonIgnore]
        public Candidate Candidate { get; set; }
        public int KnowledgeId { get; set; }
        [JsonIgnore]
        public Knowledge Knowledge { get; set; }
        public int Rate { get; set; }
    }
}
