﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class PMS_Context : DbContext
    {
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<RoleDetails> RoleDetails { get; set; }
        public DbSet<Assessment> AssessmentDetails { get; set; }
        public DbSet<CaseStudyDetails> CaseStudyDetails { get; set; }
        public DbSet<CaseStudySolutions> CaseStudySolutions { get; set; }
        public DbSet<CompetencyDetails> CompetencyDetails { get; set; }
        //public DbSet<CreateContent> createContents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PMS;Integrated Security=true;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
