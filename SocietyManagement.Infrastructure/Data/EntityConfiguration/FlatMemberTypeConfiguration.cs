using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Infrastructure.Data.EntityConfiguration
{
    public class FlatMemberTypeConfiguration
    {
        public void Initialize(EntityTypeBuilder<FlatMemberType> entity)
        {
            entity.HasKey(x => x.FlatMemberId);

        }
    }
}
