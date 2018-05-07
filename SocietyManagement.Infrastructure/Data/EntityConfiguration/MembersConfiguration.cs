using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Infrastructure.Data.EntityConfiguration
{
    public class MembersConfiguration
    {
        public void Initialize(EntityTypeBuilder<Members> entity)
        {
            entity.HasKey(x => x.MemberId);
            
        }
    }
}
