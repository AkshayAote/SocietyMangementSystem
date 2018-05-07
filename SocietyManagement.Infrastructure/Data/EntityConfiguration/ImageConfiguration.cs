using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Infrastructure.Data.EntityConfiguration
{
    public class ImageConfiguration
    {
        public void Initialize(EntityTypeBuilder<Image> entity)
        {
            entity.HasKey(x => x.Id);

        }
    }
}
