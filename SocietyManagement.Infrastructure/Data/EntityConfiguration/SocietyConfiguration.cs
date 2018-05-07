using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Infrastructure.Data.EntityConfiguration
{
    public class SocietyConfiguration
    {
        public void Initialize(EntityTypeBuilder<Society> entity)
        {
            entity.HasKey(x => x.SocietyId);

        }
    }
}
