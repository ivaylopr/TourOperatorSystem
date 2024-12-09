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
    internal class SeasonalEmploymentConfiguration : IEntityTypeConfiguration<SeasonalEmployment>
    {
        public void Configure(EntityTypeBuilder<SeasonalEmployment> builder)
        {
            var data = new SeedData();
            builder.HasData(new SeasonalEmployment[] { data.KitchenHelper, data.HouseKeeper, data.RoomService,
                                                       data.Receptionist, data.Piccolo, data.ParkingAssistance,
                                                       data.PoolLifeGuard, data.Waiter, data.Barman,
                                                       data.DishWasher});
        }
    }
}
