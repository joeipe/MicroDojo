using MicroDojoWarrior.Write.Data.EventDispatchers;
using MicroDojoWarrior.Write.Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroDojoWarrior.Write.Data
{
    public class WriteDbContext : DbContext
    {
        private readonly EventDispatcher _eventDispatcher;

        public DbSet<Belt> Belts { get; set; }
        public DbSet<Person> People { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options, EventDispatcher eventDispatcher)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _eventDispatcher = eventDispatcher;
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MicroDojoWarriorDB;Trusted_Connection=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedDate");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdatedDate");
            }

            //modelBuilder.Entity<Person>()
            //    .HasOne(e => e.Belt)
            //    .WithMany(e => e.People)
            //    .HasForeignKey(e => e.BeltId)
            //    .IsRequired();

            //modelBuilder.Entity<Belt>()
            //    .HasMany(e => e.People)
            //    .WithOne(e => e.Belt)
            //    .HasForeignKey(e => e.BeltId)
            //    .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified))
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        changedEntity.Property("CreatedDate").CurrentValue = now;
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;

                    case EntityState.Modified:
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;
                }
            }

            List<Entity> entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is Entity)
                .Select(x => (Entity)x.Entity)
                .ToList();

            int result = base.SaveChanges();

            foreach (var entity in entities)
            {
                _eventDispatcher.Dispatch(entity.DomainEvents);
                entity.ClearDomainEvents();
            }

            //return base.SaveChanges();
            return result;
        }
    }
}