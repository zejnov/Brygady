using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Brygady2.Models
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public new DbSet<Users>         Users           { get; set; }
        public DbSet<MyIdentityRole>    MyIdentityRole  { get; set; }
        public DbSet<UserTypes>         UserTypes       { get; set; }
        public DbSet<Orders>            Orders          { get; set; }
        public DbSet<SettingBackups>    SettingBackups  { get; set; }
        public DbSet<Works>             Works           { get; set; }
        public DbSet<LampToProduct>     LampsToProducts { get; set; }
        public DbSet<GPSs>              GPSs            { get; set; }
        public DbSet<Lamps>             Lamps           { get; set; }
        public DbSet<ModelLamp>         ModelLamps      { get; set; }
        public DbSet<Product>           Products        { get; set; }
        public DbSet<Categories>        Categories      { get; set; }
        public DbSet<WorksGPSs>         WorksGPSs       { get; set; }
        public DbSet<WorksUsers>        WorksUsers      { get; set; }
        public DbSet<WorksPhotos>       WorksPhotos     { get; set; }
        public DbSet<Photos>            Photos          { get; set; }
        public DbSet<Temperatures>      Temperatures    { get; set; } // testowo do usuniecia

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorksGPSs>()
                .HasKey(c => new{ c.IdGPS, c.IdWork });
             modelBuilder.Entity<WorksUsers>()
                .HasKey(c => new{ c.Id, c.IdWork });
             modelBuilder.Entity<WorksPhotos>()
                .HasKey(c => new{ c.IdPhoto, c.IdWork });
            
             modelBuilder.Entity<LampToProduct>()
                .HasKey(c => new{ c.IdProduct, c.IdLamp });
            modelBuilder.Entity<LampsOrders>()
                .HasKey(c => new{ c.IdLamp, c.IdOrder });
        } 
    } 
}
