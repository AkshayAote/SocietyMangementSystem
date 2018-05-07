using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Infrastructure.Configurations;

namespace SocietyManagement.Infrastructure.Data.DatabaseContext
{
    public class SocietyManagementDBContext:DbContext
    {
        public SocietyManagementDBContext(DbContextOptions<SocietyManagementDBContext> options) :base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SocietyManagementDbConfigurations.SetEntityConfigurations(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }

        public virtual DbSet<FlatMemberType> FlatMemberTypes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Society> Societies { get; set; }
        public virtual DbSet<SocietyFlat> SocietyFlats { get; set; }
        public virtual DbSet<Visitors> Visitorses { get; set; }
        
    }
}
