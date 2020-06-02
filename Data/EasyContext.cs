using Microsoft.EntityFrameworkCore;
using MouzartSamuelBacarinEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouzartSamuelBacarinEasy.Data
{
    public class EasyContext : DbContext
    {
        public EasyContext(
           DbContextOptions options) : base(options)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<WorkLoad> WorkLoads { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<CandidateKnowledge> CandidateKnowledges { get; set; }

    }
}
