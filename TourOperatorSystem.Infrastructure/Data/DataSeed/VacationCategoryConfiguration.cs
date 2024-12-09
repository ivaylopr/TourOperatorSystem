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
    internal class VacationCategoryConfiguration : IEntityTypeConfiguration<VacationCategory>
    {
        public void Configure(EntityTypeBuilder<VacationCategory> builder)
        {
            var data = new SeedData();
            builder.HasData(new VacationCategory[] { data.SeaCategory, data.MountainCategory, data.SpaCategory });
        }
    }
}
