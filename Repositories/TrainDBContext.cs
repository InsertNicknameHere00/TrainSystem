using Microsoft.EntityFrameworkCore;
using TrainSystem.Entities;

namespace TrainSystem.Repositories
{
    public class TrainDBContext: DbContext
            {
        public DbSet<User> Users { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public DbSet<Station> Stations { get; set; }

        public TrainDBContext()
        {
            this.Users = this.Set<User>();
            this.Trips = this.Set<Trip>();
            this.Trains = this.Set<Train>();
            this.Tickets = this.Set<Ticket>();
            this.News = this.Set<News>();
            this.Stations = this.Set<Station>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "rr",
                Password = "pass123",
                Firstname = "Rosen",
                Lastname = "Tonev",
                Email="RTonev@abv.bg"
            });
            modelBuilder.Entity<User>().HasAlternateKey(nameof(User.Username));
                        

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TrainSystemDB;User Id=RosenT;Password=rosenpass;Trusted_Connection=True;");
        }
    }
}