using SocietyManagement.Domain.Models;
using SocietyManagement.Infrastructure.Data.DatabaseContext;
using SocietyManagement.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Infrastructure.Data.Repository
{
    public class VisitorRepository: IVisitorRepository
    {
        private readonly SocietyManagementDBContext _societyManagementDbContext;

        public VisitorRepository(SocietyManagementDBContext context)
        {
            _societyManagementDbContext = context;
        }

        public bool RecordVisitor(Domain.Entities.Visitors visitor)
        {
            try
            {
                _societyManagementDbContext.Visitorses.Add(visitor);
                _societyManagementDbContext.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        } 

        public int AddImageOfIdProof(Domain.Entities.Image image)
        {
            try
            {
                var imageObj = _societyManagementDbContext.Images.Add(image);
                _societyManagementDbContext.SaveChanges();
                return image.Id;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

    }
}
