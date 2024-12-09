using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Infrastructure.Data.DataSeed
{
    internal class VacationConfiguration : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            var data = new SeedData();
            builder.HasData(new Vacation[] {data.BlackSeaStarAllInclusive,
                                            data.BanskoResortAllInclusive,
                                            data.PortoBelloAllInclusive});
        }
    }
}
