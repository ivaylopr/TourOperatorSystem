using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TourOperatorSystem.Infrastructure.Data.DataSeed;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HotelVacation>().HasKey(hv => new { hv.VacationId, hv.HodelId });
            builder.Entity<HotelVacation>()
                .HasOne(hv => hv.Hotel)
                .WithMany(hv => hv.HotelVacations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Candidate>()
                .HasOne(c => c.SeasonalEmployment)
                .WithMany(se => se.Applayers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelId, hr.RoomId });
            builder.Entity<HotelRoom>()
                .HasOne(h => h.Hotel)
                .WithMany(r => r.HotelRooms)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<VacationCustomer>().HasKey(vc => new { vc.VacationId, vc.UserId });
            builder.Entity<VacationCustomer>()
                .HasOne(vc => vc.Vacation)
                .WithMany(vc => vc.VacationCustomers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Vacation>().Property(v => v.Price).HasColumnType("decimal(18,2)");
            builder.Entity<Room>().Property(r => r.Price).HasColumnType("decimal(18,2)");
            builder.Entity<SeasonalEmployment>().Property(se => se.HourlyWage).HasColumnType("decimal(18,2)");
            builder.Entity<Hotel>().Property(h => h.AllInclusivePrice).HasColumnType("decimal(18,2)");
            builder.Entity<Hotel>()
                .HasOne(h => h.VacationCategory)
                .WithMany(vc => vc.Hotels)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new VacationCategoryConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new VacationConfiguration());
            builder.ApplyConfiguration(new SeasonalEmploymentConfiguration());
            builder.ApplyConfiguration(new CantidateConfiguration());
            builder.ApplyConfiguration(new HotelRoomConfiguration());

            base.OnModelCreating(builder);
        }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelVacation> HotelVacations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<SeasonalEmployment> SeasonalEmployments { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationCategory> VacationCategories { get; set; }
        public DbSet<VacationCustomer> VacationCustomers { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
    }
}
