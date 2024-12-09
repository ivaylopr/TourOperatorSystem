using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Infrastructure.Data.DataSeed
{
    internal class CantidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            var data = new SeedData();
            builder.HasData(new Candidate[] { data.NewGuestCandidate });
        }
    }
}
