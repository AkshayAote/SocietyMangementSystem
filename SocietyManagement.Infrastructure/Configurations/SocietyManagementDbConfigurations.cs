using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Infrastructure.Data.EntityConfiguration;

namespace SocietyManagement.Infrastructure.Configurations
{
    public class SocietyManagementDbConfigurations
    {
        public static void SetEntityConfigurations(ModelBuilder modelBuilder)
        {

            new MembersConfiguration().Initialize(modelBuilder.Entity<Members>());
            new SocietyConfiguration().Initialize(modelBuilder.Entity<Society>());
            new ImageConfiguration().Initialize(modelBuilder.Entity<Image>());
            new SocietyFlatConfiguration().Initialize(modelBuilder.Entity<SocietyFlat>());
            new VisitorConfiguration().Initialize(modelBuilder.Entity<Visitors>());
            new FlatMemberTypeConfiguration().Initialize(modelBuilder.Entity<FlatMemberType>());
            new RoleConfiguration().Initialize(modelBuilder.Entity<Role>());

        }
    }
}
