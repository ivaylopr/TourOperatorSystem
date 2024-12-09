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
    internal class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            var data = new SeedData();
            builder.HasData(new HotelRoom[] { data.BstarOne, data.BstarTwo,data.BstarTree,
                                                  data.BanskoOne, data.BanskoTwo, data.BanskoTree,
                                                  data.PortoOne, data.PortoTwo, data.PortoTree});
        }
    }
}
