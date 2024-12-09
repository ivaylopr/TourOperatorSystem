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
    internal class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            var data = new SeedData();
            builder.HasData(new Hotel[] { data.BlackSeaStar, data.BanskoResort, data.PortoBelloHotel });

        }
    }
}
