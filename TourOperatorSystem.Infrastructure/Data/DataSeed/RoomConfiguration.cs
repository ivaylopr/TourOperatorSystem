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
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            var data = new SeedData();
            builder.HasData(new Room[] {data.BlackSeaTwoBed, data.BlackSeaStudio, data.BlackSeaPresidentApart,
                                        data.BanskoResortTwoBed, data.BanskoResortStudio, data.BanskoResortPresidentApart,
                                        data.PortoBelloTwoBed, data.PortoBelloStudio, data.PortoBelloPresidentApart});
        }
    }
}
