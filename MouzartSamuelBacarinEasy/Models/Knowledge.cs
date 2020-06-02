using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouzartSamuelBacarinEasy.Models
{
    public class Knowledge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<CandidateKnowledge> CandidateKnowledges { get; set; }
    }
}
