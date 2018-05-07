using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Infrastructure.Data.EntityConfiguration
{
    class SocietyFlatConfiguration
    {
        public void Initialize(EntityTypeBuilder<SocietyFlat> entity)
        {
            entity.HasKey(x => x.SocietyFlatId);

        }
    }
}
