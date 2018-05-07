using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Infrastructure.Data.EntityConfiguration
{
    public class RoleConfiguration
    {

        public void Initialize(EntityTypeBuilder<Role> entity)
        {
            entity.HasKey(x => x.RoleId);

        }
    }
}
