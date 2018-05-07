using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Infrastructure.Data.EntityConfiguration
{
    public class VisitorConfiguration
    {
        public void Initialize(EntityTypeBuilder<Visitors> entity)
        {
            entity.HasKey(x => x.VisitorId);

        }
    }
}
